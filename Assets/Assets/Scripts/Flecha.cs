using UnityEngine;
using UnityEngine.UI;

public class Flecha : MonoBehaviour {
    public Sprite arrowSprite;
    public float scaleFactor = .7f;
    private Image arrowImage;
    private Vector3 startPos;


    private void Start() {
        // Crear la imagen de la flecha y asignarle el sprite
        GameObject arrowObj = new GameObject("Arrow");
        arrowImage = arrowObj.AddComponent<Image>();
        arrowImage.sprite = arrowSprite;
       // arrowImage.rectTransform.sizeDelta = new Vector2(5f, 5f); // Asignar un tamaño inicial
        arrowObj.transform.SetParent(GameObject.Find("Canvas").transform, false); // Asignar el canvas como padre para que la flecha aparezca en la pantalla
        arrowObj.SetActive(false); // Desactivar el objeto por defecto hasta que se necesite
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // Obtener la posición inicial del objeto
            startPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y, 0);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(startPos);
            //Debug.Log($"{startPos}");

            // Activar el objeto y colocarlo en la posición inicial
            arrowImage.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
            //Debug.Log($"{worldPos}");
            arrowImage.rectTransform.localScale = Vector3.one * scaleFactor;
            arrowImage.gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0)) {
            // Escalar la flecha hacia la posición actual del mouse
            Vector3 direction = Input.mousePosition - startPos;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
            float distance = direction.magnitude;
           // arrowImage.rectTransform.sizeDelta = new Vector2(distance, arrowImage.rectTransform.sizeDelta.y);
            arrowImage.rectTransform.sizeDelta = new Vector2(distance, distance* .6f);
        }

        if (Input.GetMouseButtonUp(0)) {
            // Desactivar el objeto cuando se suelta el mouse
            arrowImage.gameObject.SetActive(false);
        }
    }
}