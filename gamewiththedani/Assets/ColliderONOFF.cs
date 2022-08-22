
using UnityEngine;

public class ColliderONOFF : MonoBehaviour
{
    Collider m_Collider;
    void Start()
    {
        m_Collider = gameObject.AddComponent<BoxCollider>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_Collider.enabled = !m_Collider.enabled;
        }
    }
}
