using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    private bool PlayerEnter;
    [SerializeField] private BurgerCannon burgerCannon;
    private bool enemyAlive = true;
    private int speed = 3; 
    public void Die()
    {
        enemyAlive = false;
        CancelInvoke(nameof(Fire));
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerEnter && enemyAlive)
        {
            ChasePlayer();
            
        }



    }

    
    private void ChasePlayer()
    {
        
        Vector3 lookDirection = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookDirection);
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward)*speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& enemyAlive) 
        {
            
            PlayerEnter = true;
            InvokeRepeating(nameof(Fire), 0.5f, 2);
           
        }
       


        }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEnter = false;
            CancelInvoke(nameof(Fire));
        }
    }
    private void Fire()
    {
        burgerCannon.Fire();
    }


}




