using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : Weapon
{

    public GameObject laserBullet;
    public float cadencia;

    public AudioSource audioSource;

    public override float GetCadencia()
    {
        return cadencia;
    }

    public override void Shoot()
    {
        Instantiate (laserBullet, this.transform.position, Quaternion.identity, null);
        
        //Play audio
        audioSource.Play();
    }
}
