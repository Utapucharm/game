using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] private Vector3 rotationDirection = Vector3.one;
    [SerializeField] private Transform propeller;

    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float propellerSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        const float constantMultiplier = 100;
        transform.Rotate(Time.deltaTime * constantMultiplier * speed * rotationDirection);
        propeller.Rotate(Time.deltaTime * constantMultiplier * propellerSpeed * Vector3.forward);
    }
}
