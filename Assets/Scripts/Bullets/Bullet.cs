using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    
    // Update is called once per frame
    void Update () {
        transform.Translate (speed * Time.deltaTime,0, 0);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Finish" || other.tag == "Meteor") {
            Destroy (gameObject);
        }
    }

}
