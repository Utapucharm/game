using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    [SerializeField] private GameObject pickupAble;
    private Quaternion rotationOffset;

    public GameObject GetGameObject()
    {
        return pickupAble;
    }

    public void PickUp(Transform pickUpPos, bool disableCollider)
    {
        transform.position = pickUpPos.position;
        transform.rotation = pickUpPos.rotation * rotationOffset;
        transform.parent = pickUpPos;

        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = true;
        }

        if (disableCollider && TryGetComponent(out Collider collider))
        {
            collider.isTrigger = true;
        }

        if (TryGetComponent(out MeshRenderer meshRenderer))
        {
            // TODO DANI
            // ChangeAlpha(meshRenderer, 0.2f);
        }
    }

    public void Drop()
    {
        transform.parent = null;

        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
        }

        if (TryGetComponent(out Collider collider))
        {
            collider.isTrigger = false;
        }

        if (TryGetComponent(out MeshRenderer meshRenderer))
        {
            // TODO Dani
            //ChangeAlpha(meshRenderer, 1f);
        }
    }

    // TODO Daniel: Had a problem with transparent materials. Look into it.
    private void ChangeAlpha(MeshRenderer meshRenderer, float newAlpha)
    {
        Color currentColor = meshRenderer.material.color;
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

        meshRenderer.material.color = newColor;
    }

    private void Awake()
    {
        rotationOffset = transform.rotation;
    }
}
