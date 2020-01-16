using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Penetration_Test : MonoBehaviour
{

    public float resistanceAmount;

   

    public float CalculateDamage(float dist, float inputDamage)
    {
        //handle dealing damage to this gameobject here

        float outputDamage = inputDamage - (resistanceAmount + dist);

        Debug.Log("Gameobject: " + this.gameObject.name + " Input Damage: " + inputDamage.ToString() + " Output Damage: " + outputDamage.ToString());

        return outputDamage;
    }

}
