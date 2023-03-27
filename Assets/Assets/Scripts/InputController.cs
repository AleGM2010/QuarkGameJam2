using UnityEngine;
using UnityEngine.Audio;

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
    public InputAreaRestriction areaRestriction;
    private bool dentro = false;
    private bool patear = false;

    void Start() {
        ballRigidbody = GetComponent<Rigidbody2D>();
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
    }
}