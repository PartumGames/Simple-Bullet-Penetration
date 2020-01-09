using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Weapon_Pickup))]
public abstract class Weapon : MonoBehaviour//--this is an abstract class(forgot to show this in the video). 
{
    /// <summary>
    /// This class is an Abstract class, meaning it can only be inherited from. 
    /// This is the Base Class for all of our weapons. It holds all of the "General Stuff" that each weapon will have. 
    /// This class will get extended in other scripts(Point, Area) so you can build in specific functionality for that particular weapon
    /// There are 2 methods you can override (Shoot, Reload). You can add more if you need too. 
    /// </summary>



    [Header("General Info")]
    public int ammo;//--how much is currently in the weapon
    public int ammoCanHold;//--how much can this weapon hold at a time (max amount)
    public int totalAmmo;//--total amount of ammo you can have for this gun

    public float damage;
    public float range;

    public float fireCoolDown;//--how long should this weapon wait before it can shoot again
    private float timer = 0f;

    [Header("UI")]
    public Sprite customCrossHair;//--a sprite that represents the crosshair for this particular weapon

    [Header("Raycast Camera")]
    public Camera cam;//--the camera used for raycasting

    private Weapon_UI ui;

    private AudioSource myAudio;

    private bool isActive = false;



    private void Start()
    {
        ui = FindObjectOfType<Weapon_UI>();
        myAudio = GetComponent<AudioSource>();
        myAudio.playOnAwake = false;
    }

    private void Update()
    {
        if (!isActive)//--need this here. Otherwise every weapon in your game will fire when you press the LMB. 
        {
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(timer>=fireCoolDown && ammo >= 1)
            {
                Shoot();
                timer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void WeaponIsActive(bool _value)
    {
        isActive = _value;

        if (isActive)
        {
            ui.SetCrossHair(customCrossHair);
        }
        else
        {
            ui.HideUI();
        }
    }

    public void HandleUI()
    {
        ui.Update_UI(ammo, totalAmmo);
    }

    public virtual void Reload()
    {
        if (ammoCanHold <= totalAmmo)//--if you have more ammo than the gun can hold(more than a magazine/clip of ammo)
        {
            totalAmmo += ammo;//--add ammo back to total ammo
            ammo = 0;//--set the ammmo to 0
            totalAmmo -= ammoCanHold;//--remove ammoCanHold(this would be a magazine/clips worth of ammo)
            ammo += ammoCanHold;//--now add a magazine/clips worth of ammo back to your weapon
        }
        else//--you have less than a magazine/clip of ammo
        {
            ammo += totalAmmo;//--just add whatevers left to the ammo in the gun
        }

        HandleUI();
        //--play reloading animation here
    }

    public virtual void Shoot()
    {
        myAudio.Play();
        ammo -= 1;
        HandleUI();
        //--play shooting animation here
    }

    public RaycastHit GetHitData()//--returns the RayCast Hit so that other scripts will know if/what was hit
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, range))
        {
            return hit;
        }

        return hit;
    }

}
