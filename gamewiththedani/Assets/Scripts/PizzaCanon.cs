using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PizzaCanon : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private Vector3 shootForce;
    [SerializeField] private Vector3 rotationSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Fire", 0, 0.2f);  
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        //transform.Roit
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


