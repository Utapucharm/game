using UnityEngine;

public class CustomInput : MonoBehaviour
{
    private IFirable selectedGun;
  
    private void Start()
    {
        selectedGun = GetComponentInChildren<Shotgun>();
    }


    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
         
            selectedGun = GetComponentInChildren<Shotgun>();
        }
       else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            selectedGun = GetComponentInChildren<BurgerCannon>();
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            selectedGun.Fire();
        }
    }
}
