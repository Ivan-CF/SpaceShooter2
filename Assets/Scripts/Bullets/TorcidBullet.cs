using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorcidBullet : MonoBehaviour
{
    public float speed;
    public float timeTorcid;

    private float currentTimeTorcid=0;

    
    // Update is called once per frame
    void Update () {
        currentTimeTorcid += Time.deltaTime;
        if(currentTimeTorcid<timeTorcid){
            transform.Translate (speed * Time.deltaTime,0, 0);
        }else if(currentTimeTorcid>timeTorcid && currentTimeTorcid<timeTorcid*2){
            transform.Translate (0, speed * Time.deltaTime,0);        
        }else if(currentTimeTorcid>timeTorcid*2 && currentTimeTorcid<timeTorcid*3){
            transform.Translate (speed * Time.deltaTime,0, 0);
        }else if(currentTimeTorcid>timeTorcid*3 && currentTimeTorcid<timeTorcid*5){
            transform.Translate (0, -speed * Time.deltaTime,0);
        }else if(currentTimeTorcid>timeTorcid*5 && currentTimeTorcid<timeTorcid*6){
            transform.Translate (speed * Time.deltaTime,0, 0);
        }else if(currentTimeTorcid>timeTorcid*6 && currentTimeTorcid<timeTorcid*7){
            transform.Translate (0, speed * Time.deltaTime,0);
        }else{
            currentTimeTorcid = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Finish") {
            Destroy (gameObject);
        }
    }

}
