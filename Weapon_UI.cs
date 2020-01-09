using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//--need this

public class Weapon_UI : MonoBehaviour
{
    /// <summary>
    /// Handles all of the UI for the weapons. Updates ammo count, shows custom crosshair
    /// </summary>


    public Text ammoText;

    public Image crossHair;

    private void Start()
    {
        HideUI();
    }

    public void Update_UI(int _ammo, int _maxAmmo)
    {
        if (!ammoText.gameObject.activeInHierarchy)
        {
            ammoText.gameObject.SetActive(true);
        }

        ammoText.text = _ammo.ToString() + " / " + _maxAmmo.ToString();
    }

    public void SetCrossHair(Sprite _sprite)
    {
        if (!crossHair.gameObject.activeInHierarchy)
        {
            crossHair.gameObject.SetActive(true);
        }

        crossHair.sprite = _sprite;
    }

    public void HideUI()
    {
        ammoText.gameObject.SetActive(false);
        crossHair.gameObject.SetActive(false);
    }
}
