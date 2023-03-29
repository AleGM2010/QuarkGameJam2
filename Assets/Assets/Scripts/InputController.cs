using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    [SerializeField]
    private float minSwipeDistance = 20f; // Valores de reconocimiento para el dedo
    [SerializeField]
    private float maxSwipeDistance = 200f;
    [SerializeField]
    private float multiplier = 1f;
    private Rigidbody2D ballRigidbody;
    [SerializeField]
    private Ball_Sound bs;
    [SerializeField]
    public Text vidas;
    int v;
    [SerializeField]
    private RectTransform panelGameOver;


   

    public InputAreaRestriction areaRestriction;
    private bool dentro = false;
    private bool patear = false;
    Vector2 posicionInicialPelota;
    
    

    void Start() {
        Time.timeScale = 1f;
        ballRigidbody = GetComponent<Rigidbody2D>();
        posicionInicialPelota = transform.position;
        v = 3;
        vidas.text = v.ToString();
    }
    /*
    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {      
               Touch touch = Input.GetTouch(0);
               Vector2 touchPosition = touch.position;

               if (areaRestriction.IsTouchInsideRestrictedArea(touchPosition)) {
                   dentro = true;
               } else {
                   dentro = false;
               }
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && dentro) {
            fingerDownPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && dentro) {
            fingerUpPosition = Input.GetTouch(0).position;

            Vector2 swipeDirection = fingerUpPosition - fingerDownPosition;
            float distancia = swipeDirection.magnitude;

             if (swipeDirection.magnitude > minSwipeDistance && swipeDirection.magnitude < maxSwipeDistance) {

                swipeDirection.Normalize();
                Debug.Log($"Distancia: {distancia}");
                var fuerza = (distancia * multiplier)>600? 500 : (distancia * multiplier) > 100 ? distancia * multiplier: 100 ;
                Debug.Log($"Fuerza: {fuerza}");
                bs.PlaySound();
                // imprimirle una fuerza a la pelota
                ballRigidbody.AddForce(fuerza* swipeDirection) ;
            }
        }
    }
     */

    void Update() {

        if (areaRestriction.IsBallInRestrictedArea(transform.position.x,transform.position.y)) {
            patear = true;
        } else {
            patear = false;
        }

        if (Input.GetMouseButtonDown(0)) {      
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            if (areaRestriction.IsTouchInsideRestrictedArea(touchPosition)) {
                
                dentro = true;
            } else {
                dentro = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && dentro && patear) {
            fingerDownPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && dentro && patear) {
            fingerUpPosition = Input.mousePosition;

            Vector2 swipeDirection = fingerUpPosition - fingerDownPosition;
            float distancia = swipeDirection.magnitude;

            if (swipeDirection.magnitude > minSwipeDistance && swipeDirection.magnitude < maxSwipeDistance) {

                swipeDirection.Normalize();
                //Debug.Log($"Distancia: {distancia}");
                var fuerza = (distancia * multiplier) > 600 ? 500 : (distancia * multiplier) > 100 ? distancia * multiplier : 100;
                //Debug.Log($"Fuerza: {fuerza}");
                bs.PlaySound();
                // imprimirle una fuerza a la pelota
                ballRigidbody.AddForce(fuerza * swipeDirection);

            }
        }
    } // End update

    private void FixedUpdate() {
        if (v <= 0) {
            Time.timeScale = 0f;         
            panelGameOver.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("ZonaGol")) {
            Invoke("ReposicionPelota",0);
        }
    }
    public void OnBecameInvisible() {
        
        //Debug.Log("Pelota salio del chat");
        Invoke("ReposicionPelota",1);
        v--;
        vidas.text = v.ToString();
    }
   

    public void ReposicionPelota() {
        //Debug.Log("Pelota reposicionada");
        ballRigidbody.angularVelocity = 0f;
        ballRigidbody.velocity = new Vector2(0f,0f);
        this.gameObject.transform.position = posicionInicialPelota;
    }
  
}