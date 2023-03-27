using UnityEngine;

public class InputAreaRestriction : MonoBehaviour {
    [SerializeField]
    private RectTransform restrictedArea; // Assign a RectTransform in the Unity Inspector to define the restricted area

    public bool IsTouchInsideRestrictedArea(Vector2 touchPosition) {
        // Convert screen point to local point in the RectTransform
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(restrictedArea, touchPosition, Camera.main, out localPoint);

        // Check if the local point is within the bounds of the RectTransform
        return restrictedArea.rect.Contains(localPoint);
    }
    public bool IsBallInRestrictedArea(float a , float b) {  
        Vector3 ball = new Vector3(a,b,0);
        // Obtener la posición del objeto en la vista de la cámara
        Vector3 screenPos = Camera.main.WorldToScreenPoint(ball);
        // Comprobar si la posición del objeto está dentro del rectángulo del canvas
        RectTransform rectTransform = restrictedArea;
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPos, Camera.main);

    }

}