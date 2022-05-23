using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMovement : MonoBehaviour
{
    private Rigidbody rb;

    private void Unfreeze()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    private void Freeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Freeze();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Unfreeze();
    }
}
