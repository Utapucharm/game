using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject shibu;
    [SerializeField] private Transform shibuspawn;
    [SerializeField] private GameObject hitObject = null;

    [Header("UI")]
    [SerializeField] private Image crossHairDefault;
    [SerializeField] private Image crossHairGrab;

    private EditPhase editPhase = EditPhase.NotEdit;
    private GameObject currentEditable;
    private GameObject currentPickupable;

    public void Interact()
    {
        if (editPhase == EditPhase.NotEdit)
        {
            editPhase = EditPhase.Edit;

            if (currentPickupable == null)
            {
                // Create a new object
                currentEditable = Instantiate(shibu);
                Pickup(currentEditable);
            }
            else
            {
                currentEditable = currentPickupable;
                Pickup(currentEditable);
            }
        }
        else if (editPhase == EditPhase.Edit)
        {
            editPhase = EditPhase.NotEdit;
            Drop(currentEditable);

            currentEditable = null;
        }
    }

    private void Pickup(GameObject objectToPickup)
    {
        objectToPickup.transform.position = shibuspawn.position;
        objectToPickup.transform.rotation = shibuspawn.rotation;
        objectToPickup.transform.parent = shibuspawn;

        objectToPickup.GetComponent<Rigidbody>().isKinematic = true;
        objectToPickup.GetComponent<Collider>().enabled = false;
    }

    private void Drop(GameObject objectToDrop)
    {
        objectToDrop.transform.parent = null;
        objectToDrop.GetComponent<Rigidbody>().isKinematic = false;
        objectToDrop.GetComponent<Collider>().enabled = true;
    }


    private void RaycastFromScreenCenter()
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
            hitObject = hit.collider.gameObject;
            //crossHair.color = Color.red;
            if (hit.collider.TryGetComponent<Pickupable>(out var pickupable))
            {
                currentPickupable = hit.collider.gameObject;
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
            hitObject = null;
            //crossHair.color = Color.white;
            crossHairDefault.enabled = true;
            crossHairGrab.enabled = false;
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