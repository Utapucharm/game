using UnityEngine;

public class PizzaCannon : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private Vector3 shootForce;
    [SerializeField] private Vector3 rotationSpeed;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        //transform.Roit
    }

    public void Fire()
    {
       
        for (int i = 0; i < 8; i++)
        {
           int randomIngredient = Random.Range(0, ingredients.Length);
            GameObject pizzaThing = Instantiate(ingredients[randomIngredient], transform.position, transform.rotation);
         Rigidbody pizzawrb = pizzaThing.AddComponent<Rigidbody>();
        pizzawrb.AddForce(transform.TransformDirection(shootForce) * pizzawrb.mass);
        pizzaThing.AddComponent<SphereCollider>();
         
        }
       

    }


}


