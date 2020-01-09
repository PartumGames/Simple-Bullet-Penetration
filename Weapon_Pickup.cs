using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pickup : MonoBehaviour
{
    /// <summary>
    /// This class tells the "Weapon_Holder" script that this particular weapon needs to be picked up
    /// It also tells the "Weapon" that this weapon is now actively being used/shot
    /// And it tells the "Weapon_UI" to show the custom crosshair, and ammo count
    /// </summary>



    private Weapon_Holder holder;
    private Weapon myWeapon;


    private void Start()
    {
        myWeapon = GetComponent<Weapon>();
        holder = FindObjectOfType<Weapon_Holder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupWeapon();
        }
    }

    private void PickupWeapon()
    {
        holder.PickupWeapon(this.gameObject);
        myWeapon.HandleUI();
        myWeapon.WeaponIsActive(true);
    }

    public void DropWeapon()
    {
        //--just getting a random position to set the weapon gameobject down at. You can handle this anyway you like
        Vector3 pos = new Vector3(transform.position.x, 0.5f, transform.position.z + 5f);
        transform.parent = null;
        transform.position = pos;
        myWeapon.WeaponIsActive(false);
    }
}
