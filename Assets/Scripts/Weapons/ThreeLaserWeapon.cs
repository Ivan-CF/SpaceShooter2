using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeLaserWeapon : Weapon
{

    public GameObject laserBullet;
    public float cadencia;

    public override float GetCadencia()
    {
        return cadencia;
    }

    public override void Shoot()
    {
        Instantiate (laserBullet, this.transform.position, Quaternion.identity, null);
        GameObject go = Instantiate (laserBullet, this.transform.position, Quaternion.identity, null);
        go.transform.Rotate(0,0,30);
        GameObject go2 = Instantiate (laserBullet, this.transform.position, Quaternion.identity, null);
        go2.transform.Rotate(0,0,-30);
    }
}
