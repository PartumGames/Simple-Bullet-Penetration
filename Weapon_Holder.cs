using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Holder : MonoBehaviour
{
    /// <summary>
    /// Script that handles positioning the weapon in the player hand, as well as dropping the weapon on a key press
    /// </summary>


    public Transform hand;
    public GameObject weapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }
    }

    public void PickupWeapon(GameObject _weapon)
    {
        DropWeapon();
        weapon = _weapon;
        weapon.transform.SetParent(hand);
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
    }

    public void DropWeapon()
    {
        if (weapon != null)//--need to check if we are currently holding a weapon, before we drop it. You will get errors if you don't
        {
            weapon.GetComponent<Weapon_Pickup>().DropWeapon();
            weapon = null;
        }
    }
}
