using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSelf : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    // Update is called once per frame
    void Update()
    {
        const float constantMultiplier = 100;
        transform.Rotate(Time.deltaTime * speed * constantMultiplier * Vector3.forward);       
    }
}
