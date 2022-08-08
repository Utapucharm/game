using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject shibu;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            shibu.transform.parent = null;
            shibu.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
