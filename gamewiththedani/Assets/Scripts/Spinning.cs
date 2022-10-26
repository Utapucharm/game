using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] private Vector3 speedDirection;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(speedDirection * Time.deltaTime);
    }
}
