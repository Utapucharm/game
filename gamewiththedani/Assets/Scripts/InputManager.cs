using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] PlayerLook playerLook;
    [SerializeField] WallRun wallRun;
    [SerializeField] BurgerCannon burgerCannon;
    [SerializeField] PizzaCannon pizzaCannon;
    [SerializeField] WeaponType weaponType = WeaponType.BurgerCannon;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponType = WeaponType.PizzaCannon;
        }


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponType = WeaponType.BurgerCannon;
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
            wallRun.CheckWallJump(wantsToJump: true);
        }
        else
        {
            wallRun.CheckWallJump(wantsToJump: false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (weaponType == WeaponType.BurgerCannon)
            {
                burgerCannon.Fire();
            }
        else if (weaponType == WeaponType.PizzaCannon)
            {
                pizzaCannon.Fire();
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        player.SetInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        player.UpdateSpeed(isSprinting: Input.GetButton("Sprint"));

        playerLook.Look(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }
}
