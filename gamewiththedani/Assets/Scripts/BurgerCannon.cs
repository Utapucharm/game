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
        Fire(null);
    }

    public void Fire(Transform target)
    {
        GameObject newBurger = Instantiate(burger, burgerStartPosition.position, burgerStartPosition.rotation);
        Rigidbody burgerRigidbody = newBurger.GetComponent<Rigidbody>();
        burgerRigidbody.mass = 1000;

        if (target != null)
        { 
            newBurger.transform.LookAt(target);
        }
       
        burgerRigidbody.AddForce(newBurger.transform.TransformDirection(shootForce) * burgerRigidbody.mass);
    }
}
