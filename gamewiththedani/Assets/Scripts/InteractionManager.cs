using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject shibu;
    [SerializeField] private Transform shibuspawn;
    private EditPhase editPhase = EditPhase.NotEdit;
    private GameObject CurrentShibu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (editPhase == EditPhase.NotEdit)
            {
                CurrentShibu = Instantiate(shibu, shibuspawn.position, shibuspawn.rotation, shibuspawn);
                editPhase = EditPhase.Edit;

            }

            else if (editPhase == EditPhase.Edit)
            {
                CurrentShibu.transform.parent = null;
                CurrentShibu.GetComponent<Rigidbody>().isKinematic = false;
                CurrentShibu.AddComponent<BoxCollider>();
                editPhase = EditPhase.NotEdit;
            }

        }
         
    
    
    }



}


public enum EditPhase
{
    NotEdit, 
    Edit
}