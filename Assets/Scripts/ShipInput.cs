using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    private Vector2 axis;

    public PlayerBehaviour ship;
    public Background bg;

  
    // Update is called once per frame
    void Update () {
        axis.x = Input.GetAxis ("Horizontal");
        axis.y = Input.GetAxis ("Vertical");

        if(Input.GetButton("Fire1")){
            ship.Shoot();
        }

        ship.ActualizaDatosInput(axis);
        bg.SetVelocity(axis.x);
    }

}
