using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;//--neeed this

public class Bullet_Penetration : Weapon
{

    public override void Shoot()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        HandleDamage(SortTheList(Physics.RaycastAll(ray, range)));
    }

    private List<RaycastHit> SortTheList(RaycastHit[] _hits)
    {
        return _hits.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }

    private void HandleDamage(List<RaycastHit> _hits)
    {
        float currentDamage = damage;//--100% damage 

        foreach (RaycastHit hit in _hits)
        {
            Pen_Test test = hit.collider.GetComponent<Pen_Test>();

            if (test != null)
            {
                float dist = Vector3.Distance(transform.position, hit.collider.transform.position);

                currentDamage = test.CalculateDamage(currentDamage, dist);

                if (currentDamage <= 0)
                {
                    break;
                }

            }
            else
            {
                break;
            }
        }
    }



}
