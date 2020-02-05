using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Vector2 speed;
    Transform graphics;

    public ParticleSystem ps;

    public AudioSource audioSource;

    public GameObject meteorToInstanciate;

    public void Awake()
    {
        graphics = transform.GetChild(0);

        for(int i=0; i<graphics.childCount;i++){
            graphics.GetChild(i).gameObject.SetActive(false);
        }

        int seleccionado = Random.Range(0,graphics.childCount);
        graphics.GetChild(seleccionado).gameObject.SetActive(true);

        speed.x = Random.Range(-5,-2);
        speed.y = Random.Range(-3,3);
    }

    void Update(){
        transform.Translate(speed*Time.deltaTime);
        graphics.Rotate(0,0,100*Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Finish"){
            Destroy(this.gameObject);
        } else if(other.tag == "Bullet") {
            StartCoroutine(DestroyMeteor());
        }
    }

    IEnumerator DestroyMeteor(){
        //Desactivo el grafico
        graphics.gameObject.SetActive(false);

        //Elimino el BoxCollider2D
        Destroy(GetComponent<BoxCollider2D>());

        //Lanzo la partícula
        ps.Play();

        //Lanzo sonido de explosion
        audioSource.Play();

        //Instanciamos 2 meteoritos medianos
        InstanceMeteors();

        //Me espero 1 segundo
        yield return new WaitForSeconds(1.0f);
        
        //Me destruyo a mi mismo
        Destroy(this.gameObject);
    }

    public virtual void InstanceMeteors(){
        Instantiate (meteorToInstanciate, this.transform.position, Quaternion.identity, null);
        Instantiate (meteorToInstanciate, this.transform.position, Quaternion.identity, null);
        Instantiate (meteorToInstanciate, this.transform.position, Quaternion.identity, null);
        Instantiate (meteorToInstanciate, this.transform.position, Quaternion.identity, null);
    }
}
