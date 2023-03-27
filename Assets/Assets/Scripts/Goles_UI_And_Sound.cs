using UnityEngine;
using UnityEngine.UI;

public class Goles_UI_And_Sound : MonoBehaviour {
    [SerializeField] private Text golesText;
    [SerializeField] private BoxCollider2D boxCollider;
    int goles = 0;
    [SerializeField]
    private Goal_Sound gs;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Pelota")) {
            goles += 1;
            gs.PlaySound();
            golesText.text = "Goles! : "+goles.ToString();
        }
    }
}

