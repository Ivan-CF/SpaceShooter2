using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorcidWeapon : Weapon
{

    public GameObject torcidBullet;
    public float cadencia;

    public override float GetCadencia()
    {
        return cadencia;
    }

    public override void Shoot()
    {
        Instantiate (torcidBullet, this.transform.position, Quaternion.identity, null);
    }
}
