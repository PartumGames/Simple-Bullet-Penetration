using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : Weapon//--inherit everything from the "Weapon" script
{

    /// <summary>
    /// Extends the "Weapon" scripts functionality. 
    /// "Area" is used for anything that fires an explosive round(Rocket Launchers, Grenade Launchers....)
    /// </summary>


    public float blastRadius;

    public override void Shoot()//--overriding the Shoot() method from the "Weapon" script
    {
        base.Shoot();//--call the base method so the UI/Ammo will update

        RaycastHit hit = GetHitData();//--get the Raycast Hit from the GetHitData() method in the Weapon Script

        if(hit.collider != null)//--did our raycast actually hit something
        {
            Collider[] colls = Physics.OverlapSphere(hit.point, blastRadius);//--start at the point the raycast hit, and create a sphere

            for (int i = 0; i < colls.Length; i++)//--loop thru the array
            {
                if (colls[i].CompareTag("Enemy"))//--if this colliders tag is = "Enem"
                {
                    hit.collider.GetComponent<Enemy>().TakeDamage(damage);//--get the enemy script, and call the Take Damage method
                    //add explosive force to rigidbody here
                }
            }
        }
    }
}
