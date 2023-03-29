using UnityEngine;
using UnityEngine.UI;

public class Goles_UI_And_Sound : MonoBehaviour {
    [SerializeField] 
    private Text golesText;
    [SerializeField] 
    private BoxCollider2D boxCollider;
    public int goles = 0;
    [SerializeField]
    public Goal_Sound gs;
    [SerializeField]
    private Text golesPanelInferior;
    [SerializeField]
    private Text golesPanelGameOver;
    [SerializeField]
    private GameObject porteria;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Pelota")) {
            goles += 1;
            gs.PlaySound();
            golesText.text =goles.ToString();
            Goles();
            if (goles > 1 && goles % 3 == 0) {
                Porteria_Controller scriptA = porteria.GetComponent<Porteria_Controller>();
                scriptA.aumentarVelocidad();
                
            }
        }      
    }

    private void Goles() {
        golesPanelGameOver.text = golesPanelInferior.text;
    }
}

