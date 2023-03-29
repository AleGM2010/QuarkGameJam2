using UnityEngine;
using UnityEngine.UI;

public class Porteria_Controller : MonoBehaviour {


    
    private Bounds screenBounds;
    [SerializeField]
    private float speed = 1.4f;
    private Vector3 startPos;
    private bool moveRight = true;
    float distance;
    [SerializeField]
    float range = 1.4f; // Ya calculado segun medida del sprite del soccer Goal (Porteria)
   


    private void Start() {
        transform.position = new Vector3(0,transform.position.y,0);
        screenBounds = CameraUtils.OrthographicBounds;
        distance = screenBounds.size.x/2;
        startPos = transform.position;
        
    }

    public void aumentarVelocidad() {
        speed += .5f;
    }

    void Update() {
        
        

        // Mover hacia la derecha
        if (moveRight) {
            transform.position = Vector3.MoveTowards(transform.position, startPos + new Vector3(distance-range, 0, 0), speed * Time.deltaTime);
            // Si llega al borde derecho, cambiar de dirección
            if (transform.position.x >= startPos.x + distance -range) {
                moveRight = false;
            }
        }
        // Mover hacia la izquierda
        else {
            transform.position = Vector3.MoveTowards(transform.position, startPos - new Vector3(distance-range, 0, 0), speed * Time.deltaTime);
            // Si llega al borde izquierdo, cambiar de dirección
            if (transform.position.x <= startPos.x - distance + range) {
                moveRight = true;
            }
        }
    }
}
