using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;
    private int elegido;

    [SerializeField] BoxCollider2D collider;
    [SerializeField] ParticleSystem ps;
    [SerializeField] AudioSource audioSource;

    private float timeCounter;
    private float timeToShoot;

    private float timeShooting;
    private float speedx;

    private bool isShooting;

    private ScoreManager sm;

    public int puntuacion = 100;

    [SerializeField] GameObject bullet;

    private void Awake() {
        
        elegido = Random.Range(0,sprites.Length);

        for(int kk=0;kk<sprites.Length;kk++){
            sprites[kk].SetActive(false);
        }

        sprites[elegido].SetActive(true);

        sm = (GameObject.Find("ScoreCanvas")).GetComponent<ScoreManager>();

        Inicitialization();
    }

    protected virtual void Inicitialization(){
        timeCounter = 0.0f;
        timeToShoot = 1.0f;
        timeShooting = 1.0f;
        speedx = 3.0f;
        isShooting = false;
    }

    protected virtual void EnemyBehaviour(){
        timeCounter += Time.deltaTime;

        if(timeCounter>timeToShoot){
            if(!isShooting){
                isShooting = true;
                Instantiate(bullet,this.transform.position,Quaternion.Euler(0,0,180),null);
            }
            if(timeCounter>(timeToShoot+timeShooting)){
                timeCounter = 0.0f;
                isShooting = false;
            }
        }else{
            transform.Translate(-speedx*Time.deltaTime,0,0);
        }

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        EnemyBehaviour();
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet") {
            StartCoroutine(DestroyShip());
        }else if(other.tag == "Finish"){
            Destroy(this.gameObject);
        }
    }


    IEnumerator DestroyShip(){
        //Sumar puntos
        sm.AddScore(puntuacion);

        //Desactivo el grafico
        sprites[elegido].SetActive(false);

        //Elimino el BoxCollider2D
        collider.enabled = false;

        //Lanzo la partícula
        ps.Play();

        //Lanzo sonido de explosion
        audioSource.Play();

        //Me espero 1 segundo
        yield return new WaitForSeconds(1.0f);
      
        Destroy(this.gameObject);
    }
}
