using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour

{
    // Start is called before the first frame update



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        Rigidbody burgerRigidbody = GetComponent<Rigidbody>();
        burgerRigidbody.mass = 2;
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Die();

        }
    }
}
