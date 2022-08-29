using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject shibu;
    [SerializeField] private Transform shibuspawn;

    [Header("UI")]
    [SerializeField] private Image crossHairDefault;
    [SerializeField] private Image crossHairGrab;

    private EditPhase editPhase = EditPhase.NotEdit;
    private TransformType transformType = TransformType.None;

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
                Pickup(currentEditable, disableCollider: true);
            }
            else
            {
                currentEditable = currentPickupable;
                Pickup(currentEditable, disableCollider: true);
            }
        }
        else if (editPhase == EditPhase.Edit)
        {
            editPhase = EditPhase.NotEdit;
            Drop(currentEditable);

            currentEditable = null;
        }
    }

    private void Pickup(GameObject objectToPickup, bool disableCollider)
    {
        objectToPickup.transform.position = shibuspawn.position;
        objectToPickup.transform.rotation = shibuspawn.rotation;
        objectToPickup.transform.parent = shibuspawn;

        if (objectToPickup.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = true;
        }

        if(disableCollider && objectToPickup.TryGetComponent(out Collider collider))
        {
            collider.isTrigger = true;
        }

        if (objectToPickup.TryGetComponent(out MeshRenderer meshRenderer))
        {
            ChangeAlpha(meshRenderer, 0.2f);
        }
    }

    private void Drop(GameObject objectToDrop)
    {
        objectToDrop.transform.parent = null;
        
        if (objectToDrop.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
        }

        if (objectToDrop.TryGetComponent(out Collider collider))
        {
            collider.isTrigger = false;
        }

        if (objectToDrop.TryGetComponent(out MeshRenderer meshRenderer))
        {
            ChangeAlpha(meshRenderer, 1f);
        }
    }

    // TODO Daniel: Had a problem with transparent materials. Look into it.
    private void ChangeAlpha(MeshRenderer meshRenderer, float newAlpha)
    {
        Color currentColor = meshRenderer.material.color;
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

        meshRenderer.material.color = newColor;
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
                //crossHair.color = Color.white;
                crossHairDefault.enabled = true;
                crossHairGrab.enabled = false;
            }
        }
    }

    private void Update()
    {
        RaycastFromScreenCenter();

        if (editPhase == EditPhase.Edit)
        {
            if (Input.GetKey(KeyCode.W))
            {
                print("ROTATE");
                currentEditable.transform.Rotate(10 * Time.deltaTime * Vector3.right);
            }
        }
    }
}


public enum EditPhase
{
    NotEdit, 
    Edit
}

public enum TransformType
{
    None,
    Move,
    Rotate,
    Scale
}