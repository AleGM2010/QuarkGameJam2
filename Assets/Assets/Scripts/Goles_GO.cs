
using UnityEngine;
using UnityEngine.UI;

public class Goles_GO : MonoBehaviour
{
    [SerializeField]
    Text golesPanelInferior;
    [SerializeField]
    Text golesPanelGameOver;

    
    private void Goles() {
        golesPanelGameOver.text = golesPanelInferior.text;
    }
    
}
