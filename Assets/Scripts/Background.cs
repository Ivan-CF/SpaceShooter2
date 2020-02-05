using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    private Material mat;
    public float smooth = 1.0f;
    private float offsetX = 0.0f;
    //
    private Vector2 textoffset;

    private float axisx;


    // Use this for initialization
    void Awake () {
        mat = GetComponent<Renderer> ().material;
        textoffset = new Vector2 (offsetX,0);
    }
    
    // Update is called once per frame
    void Update () {
        offsetX += (Time.deltaTime * (smooth  + 75*axisx/100));
        if(offsetX >= 100) offsetX -= 100;

        textoffset.x = offsetX;
        mat.SetTextureOffset("_MainTex", textoffset);
    }

    public void SetVelocity(float velx){
        axisx = velx;
    }
}
