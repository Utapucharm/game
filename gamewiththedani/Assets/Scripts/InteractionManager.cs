using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject shibu;
    [SerializeField] private Transform pickUpPos;

    [Header("UI")]
    [SerializeField] private Image crossHairDefault;
    [SerializeField] private Image crossHairGrab;

    private EditPhase editPhase = EditPhase.NotEdit;

    private Pickupable currentEditable;
    private Pickupable currentPickupable;

    public void Interact()
    {
        if (editPhase == EditPhase.NotEdit)
        {
            editPhase = EditPhase.Edit;

            if (currentPickupable == null)
            {
                // Create a new object
                currentEditable = Instantiate(shibu).GetComponentInChildren<Pickupable>();
                print(currentEditable);
                PickUp(currentEditable, disableCollider: true);
            }
            else
            {
                currentEditable = currentPickupable;
                PickUp(currentEditable, disableCollider: true);
            }
        }
        else if (editPhase == EditPhase.Edit)
        {
            editPhase = EditPhase.NotEdit;
            Drop(currentEditable);

            currentEditable = null;
        }
    }

    private void PickUp(Pickupable objectToPickup, bool disableCollider)
    {
        objectToPickup.PickUp(pickUpPos, disableCollider);
    }

    private void Drop(Pickupable objectToDrop)
    {
        objectToDrop.Drop();
    }

    private void RaycastFromScreenCenter()
    {
        if (editPhase == EditPhase.NotEdit)
        {
            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
            float rayLength = 5f;

            // actual Ray
            Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

            //// debug Ray
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                //crossHair.color = Color.red;
                if (hit.collider.TryGetComponent<Pickupable>(out var pickupable) && editPhase == EditPhase.NotEdit)
                {
                    currentPickupable = pickupable;
                    crossHairDefault.enabled = false;
                    crossHairGrab.enabled = true;
                }
                else
                {
                    currentPickupable = null;
                    crossHairDefault.enabled = true;
                    crossHairGrab.enabled = false;
                }
            }
            else
            {
                currentPickupable = null;
                //crossHair.color = Color.white;
                crossHairDefault.enabled = true;
                crossHairGrab.enabled = false;
            }
        }
    }

    private void Update()
    {
        RaycastFromScreenCenter();
    }
}


public enum EditPhase
{
    NotEdit, 
    Edit
}
