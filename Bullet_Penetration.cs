using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet_Penetration : Weapon
{

    public override void Shoot()
    {

        Debug.Log("/----------------------Shooting------------------/");

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray, range);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.collider.CompareTag("Enemy"))
            {
                CalculateDamage(hit.collider.gameObject);
            }
        }

    }

    private void CalculateDamage(GameObject go)
    {
        float dist = Vector3.Distance(transform.position, go.transform.position);

        float bulletDamage = damage - dist;

        if (damage >= 0)
        {
            //--health script -> bulletDamage
            Debug.Log(go.name + " Took: " + bulletDamage.ToString() + " Of Damage");
        }
    }


}
