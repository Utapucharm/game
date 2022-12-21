using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private Transform cameraRotation;

    void Update()
    {
        transform.rotation = cameraRotation.rotation;
    }
}
