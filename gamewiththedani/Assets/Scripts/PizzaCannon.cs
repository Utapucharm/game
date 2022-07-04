using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PizzaCannon : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private Vector3 shootForce;

    // Start is called before the first frame update
    private void Start()
    {
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 69 * Time.deltaTime, 0, Space.Self);
    }
    public void Fire()
    {
        int randomIngredient = Random.Range(0, ingredients.Length);
        GameObject pizzaThing = Instantiate(ingredients[randomIngredient], transform.position, transform.rotation);
        Rigidbody pizzawrb = pizzaThing.AddComponent<Rigidbody>();
        pizzawrb.AddForce(transform.TransformDirection(shootForce) * pizzawrb.mass);
        pizzaThing.AddComponent<SphereCollider>();

    }


}


