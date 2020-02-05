using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float timeLauchMeteor;

    private float currentTime = 0;

    void Awake(){
        StartCoroutine(LanzaMeteoritos());
    }

    // Update is called once per frame
    /*
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>timeLauchMeteor){
            currentTime = 0;
            Instantiate(meteorPrefab,new Vector3(10,Random.Range(-5,5)),Quaternion.identity,this.transform);
        }
    }
    */

    IEnumerator LanzaMeteoritos(){
        while(true){
            Instantiate(meteorPrefab,new Vector3(10,Random.Range(-5,5)),Quaternion.identity,this.transform);
            yield return new WaitForSeconds(timeLauchMeteor);
        }
    }

}
