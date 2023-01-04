using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BurgerCannon burgerCannon;
    [SerializeField] private int speed = 3;
    private bool isAlive = true;
    private bool playerIsClose;

    public void Die()
    {
        isAlive = false;
        CancelInvoke(nameof(Fire));
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerIsClose && isAlive)
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
        if (other.gameObject.CompareTag("Player")&& isAlive) 
        {
            playerIsClose = true;
            InvokeRepeating(nameof(Fire), 0.5f, 2);  
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
            CancelInvoke(nameof(Fire));
        }
    }

    private void Fire()
    {
        burgerCannon.Fire();
    }

}




