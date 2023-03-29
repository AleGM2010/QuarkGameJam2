
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel_GO_Controller : MonoBehaviour
{  
    [SerializeField]
    private RectTransform panel;

    void Start() {
        panel.gameObject.SetActive(false);
        panel = GetComponent<RectTransform>();
        CrearPanelResponsive();
    }
    public void Restart() {
        SceneManager.LoadScene("Game");
        
    }

    private void CrearPanelResponsive() {
        panel.position = new Vector3(0,0,0);
        panel.sizeDelta = new Vector2(Screen.width*.8f,Screen.height*.6f);
    }
}
