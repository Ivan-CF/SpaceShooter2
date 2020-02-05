using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBullet : MonoBehaviour
{
    public float speed;

    
    // Update is called once per frame
    void Update () {
        transform.Translate (0, speed * Time.deltaTime,0);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Finish") {
            Destroy (gameObject);
        }
    }

}
