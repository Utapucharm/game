using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PizzaCanon : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Fire", 0, 0.2f);
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void Fire()
    {
        int randomIngredient = Random.Range(0, ingredients.Length);
        Instantiate(ingredients[randomIngredient], transform.position, transform.rotation);

    }

}


