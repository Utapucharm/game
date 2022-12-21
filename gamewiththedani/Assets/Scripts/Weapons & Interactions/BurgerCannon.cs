using UnityEngine;

public class BurgerCannon : MonoBehaviour, IFirable
{
    [SerializeField] private GameObject burger;
    [SerializeField] private Transform burgerStartPosition;
    [SerializeField] private Vector3 shootForce;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Fire();
        }
    }

    public void Fire()
    {
        GameObject newBurger = Instantiate(burger, burgerStartPosition.position, burgerStartPosition.rotation);
        Rigidbody burgerRigidbody = newBurger.GetComponent<Rigidbody>();
        burgerRigidbody.mass = 1000;

        burgerRigidbody.AddForce(newBurger.transform.TransformDirection(shootForce) * burgerRigidbody.mass);
    }
}
