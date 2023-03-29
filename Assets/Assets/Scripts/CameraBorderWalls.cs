using UnityEngine;

public class CameraBorderWalls : MonoBehaviour {

    [SerializeField]
    public BoxCollider2D topWall;
    [SerializeField]
    public BoxCollider2D rightWall;
    [SerializeField]
    public BoxCollider2D bottomWall;
    [SerializeField]
    public BoxCollider2D leftWall;
    [SerializeField]
    private Bounds screenBounds;

    void Start() {
        screenBounds = CameraUtils.OrthographicBounds;
        PositionWalls();
    }

    void PositionWalls() {
        float halfWidth = screenBounds.size.x / 2;
        float halfHeight = screenBounds.size.y / 2;
        Vector3 cameraPosition = Camera.main.transform.position;

        rightWall.gameObject.transform.position = new Vector3(cameraPosition.x + halfWidth, cameraPosition.y - halfHeight, 0);
        leftWall.gameObject.transform.position = new Vector3(cameraPosition.x - halfWidth, cameraPosition.y - halfHeight, 0);

        bottomWall.gameObject.transform.position = new Vector3(cameraPosition.x, cameraPosition.y - halfHeight, 0);

        //topWall.size = new Vector2(screenBounds.size.x, topWall.size.y);
        rightWall.size = new Vector2(rightWall.size.x, screenBounds.size.y*.3f);
        bottomWall.size = new Vector2(screenBounds.size.x, bottomWall.size.y);
        leftWall.size = new Vector2(leftWall.size.x, screenBounds.size.y*.3f);
    }
}