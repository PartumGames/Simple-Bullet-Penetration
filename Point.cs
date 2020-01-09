using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : Weapon//--inherit everything from the "Weapon" script
{
    /// <summary>
    /// Extends the "Weapon" scripts functionality. 
    /// "Point" is used for anything that fires a single bullet at a time(Rifles, pistols, sniper rifles, shotguns, machine guns....)
    /// </summary>


    public override void Shoot()//--overriding the Shoot() method from the "Weapon" script
    {
        base.Shoot();//--call the base method so the UI/Ammo will update

        RaycastHit hit = GetHitData();//--get the Raycast Hit from the GetHitData() method in the Weapon Script

        if (hit.collider != null && hit.collider.CompareTag("Enemy"))//--if we actually hit something and it was tagged as "Enemy"
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(damage);//--get the enemy script, and call the Take Damage method
        }
    }

}
