using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] formaciones;
    public float timeLaunchFormation;

    private float currentTime = 0;

    void Awake(){
        StartCoroutine(LanzaFormacion());
    }

    IEnumerator LanzaFormacion(){
        int formacionActual=0;
        while(true){
            formacionActual = Random.Range(0,formaciones.Length); 

            Instantiate(formaciones[formacionActual],new Vector3(10,Random.Range(-5,5)),Quaternion.identity,this.transform);
            yield return new WaitForSeconds(timeLaunchFormation);
        }
    }

}