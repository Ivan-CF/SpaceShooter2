using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour {

    public TrailRenderer blue01;
    public TrailRenderer blue02;
    public TrailRenderer red01;
    public TrailRenderer red02;


    // Use this for initialization
    void Awake () {
        Stop ();
    }
    
    public void BlueFire(){
        blue01.emitting = true;
        blue02.emitting = true;
        red01.emitting = false;
        red02.emitting = false;
    }

    public void RedFire(){
        blue01.emitting = false;
        blue02.emitting = false;
        red01.emitting = true;
        red02.emitting = true;
    }

    public void Stop(){
        blue01.emitting = false;
        blue02.emitting = false;
        red01.emitting = false;
        red02.emitting = false;
    }
}

