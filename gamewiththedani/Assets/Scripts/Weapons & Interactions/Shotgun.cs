using UnityEngine;

public class Shotgun : MonoBehaviour, IFirable
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Vector3 shootForce;
    [SerializeField] private int popcornNumber = 5;
    [SerializeField] private float spreadPopcorn = 6.9f;


    public void Fire()
    {
        for (int i = 0; i < popcornNumber; i++)
        {
            Vector3 offset = CoolMath.CalculateCirclePoint(0.69f, 360/popcornNumber*i); 
            GameObject currentProjectile = Instantiate(projectile, shootPoint.position + transform.TransformDirection(offset), shootPoint.rotation);
            Rigidbody burgerRigidbody = currentProjectile.GetComponent<Rigidbody>();
            burgerRigidbody.mass = 1000;
            
            Vector3 direction = offset - shootPoint.position;
            direction = direction.normalized;
            
            burgerRigidbody.AddForce((shootPoint.transform.TransformDirection(shootForce)+ direction * spreadPopcorn) * burgerRigidbody.mass);
        }
    }
}
