using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    private Vector2 axis;
    public Vector2 limits;

    private float shootTime=0;

    public Weapon weapon;

    public Propeller prop;
    
    [SerializeField] GameObject graphics;
    [SerializeField] Collider2D collider;
    [SerializeField] ParticleSystem ps;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ScoreManager scoreManager;

    public int lives = 3;
    private bool iamDead = false;
    
    // Update is called once per frame
    void Update () {
        if(iamDead){
            return;
        }

        shootTime += Time.deltaTime;

        transform.Translate (axis * speed * Time.deltaTime);

        if (transform.position.x > limits.x) {
            transform.position = new Vector3 (limits.x, transform.position.y, transform.position.z);
        }else if (transform.position.x < -limits.x) {
            transform.position = new Vector3 (-limits.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y > limits.y) {
            transform.position = new Vector3 (transform.position.x, limits.y, transform.position.z);
        }else if (transform.position.y < -limits.y) {
            transform.position = new Vector3 (transform.position.x, -limits.y, transform.position.z);
        }

        if(axis.x>0){
            prop.BlueFire();
        }else if(axis.x<0){
            prop.RedFire();
        }else{
            prop.Stop();
        }
    }

    public void ActualizaDatosInput(Vector2 currentAxis){
        axis = currentAxis;
    }

    public void SetAxis(float x, float y){
        axis = new Vector2(x,y);
    }

    public void SetAxis(Vector2 currentAxis){
        axis = currentAxis;
    }

    public void Shoot(){
        if(shootTime>weapon.GetCadencia()){
            shootTime = 0f;
            weapon.Shoot();
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Meteor" || other.tag == "EnemyBullet") {
            StartCoroutine(DestroyShip());
        }
    }

    IEnumerator DestroyShip(){
        //Indico que estoy muerto
        iamDead=true;

        //Me quito una vida
        lives--;

        //Desactivo el grafico
        graphics.SetActive(false);

        //Elimino el BoxCollider2D
        collider.enabled = false;

        //Lanzo la partícula
        ps.Play();

        //Lanzo sonido de explosion
        audioSource.Play();

        //Desactivo el propeller
        prop.gameObject.SetActive(false);

        //Indicamos al score que hemos perdido una vida
        scoreManager.LoseLife();

        //Me espero 1 segundo
        yield return new WaitForSeconds(1.0f);
        
        //Miro si tengo mas vidas
        if(lives>0){
            StartCoroutine(inMortal());
        }
    }

    IEnumerator inMortal(){
        //Vuelvo a activar el jugador
        iamDead = false;
        graphics.SetActive(true);
        //Activo el propeller
        prop.gameObject.SetActive(true);

        for(int i=0;i<15;i++){
            graphics.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            graphics.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        //Activo el collider
        collider.enabled = true;
    }

}
