using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCannon : MonoBehaviour
{
    [SerializeField] private GameObject burger;
    [SerializeField] private Transform burgerStartPosition;
    [SerializeField] private Vector3 shootForce;

    public void Fire()
    {
        GameObject newBurger = Instantiate(burger, burgerStartPosition.position, burgerStartPosition.rotation);
        Rigidbody burgerRigidbody = newBurger.GetComponent<Rigidbody>();
        burgerRigidbody.AddForce(burgerStartPosition.TransformDirection(shootForce) * burgerRigidbody.mass);
    }

    public void Fire(Transform target)
    {
        GameObject newBurger = Instantiate(burger, burgerStartPosition.position, burgerStartPosition.rotation);
        Rigidbody burgerRigidbody = newBurger.GetComponent<Rigidbody>();

        newBurger.transform.LookAt(target);


        burgerRigidbody.AddForce(newBurger.transform.TransformDirection(shootForce) * burgerRigidbody.mass);
    }
}
