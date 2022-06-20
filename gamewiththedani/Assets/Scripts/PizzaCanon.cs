using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PizzaCanon : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private Vector3 shootForce;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Fire", 0, 0.2f);
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(transform.TransformDirection(0,0 , 69 * Time.deltaTime));
    }
    private void Fire()
    {
        int randomIngredient = Random.Range(0, ingredients.Length);
        GameObject pizzaThing = Instantiate(ingredients[randomIngredient], transform.position, transform.rotation);
        Rigidbody pizzawrb = pizzaThing.AddComponent<Rigidbody>();
        pizzawrb.AddForce(transform.TransformDirection(shootForce) * pizzawrb.mass);
        pizzaThing.AddComponent<SphereCollider>();

    }


}


