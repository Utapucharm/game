using UnityEngine;

public class Shotgun : MonoBehaviour, IFirable
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Vector3 shootForce;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        { 
            Fire();
        }
    }

    public void Fire()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 offset = CoolMath.CalculateCirclePoint(0.69f, 360/5*i); 
            GameObject currentProjectile = Instantiate(projectile, shootPoint.position + transform.TransformDirection(offset), shootPoint.rotation);
            Rigidbody burgerRigidbody = currentProjectile.GetComponent<Rigidbody>();
            burgerRigidbody.mass = 1000;
       
            burgerRigidbody.AddForce(currentProjectile.transform.TransformDirection(shootForce) * burgerRigidbody.mass);
        }
    }
}
