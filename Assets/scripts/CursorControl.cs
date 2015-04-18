using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

    public int playerNumber = 1;
    public float maxSpeed = 1f;
    public Vector2 topLeftBound;
    public Vector2 bottomRightBound;
    private Rigidbody2D body;
    private string horizontalAxis = "Horizontal1";
    private string verticalAxis = "Vertical1";
    private string dropButton = "Drop1";
    private Vector2 parentLocation;

    void Awake () {
        body = this.GetComponent<Rigidbody2D>() as Rigidbody2D;
        parentLocation = transform.position;
        if (playerNumber != 1) {
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
            dropButton = "Drop2";
        }
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        float hSpeed = Input.GetAxis(horizontalAxis);
        float vSpeed = Input.GetAxis(verticalAxis);

        body.velocity = new Vector2 (hSpeed * maxSpeed, vSpeed * maxSpeed);

        float newX = transform.localPosition.x;
        float newY = transform.localPosition.y;
        // bound the cursor to the box
        if (transform.localPosition.x <= topLeftBound.x) {
            newX = topLeftBound.x;
        } else if (transform.localPosition.x >= bottomRightBound.x) {
            newX = bottomRightBound.x;
        }
        if (transform.localPosition.y >= topLeftBound.y) {
            newY = topLeftBound.y;
        } else if(transform.localPosition.y <= bottomRightBound.y) {
            newY = bottomRightBound.y;
        }
        transform.localPosition = new Vector2 (newX, newY);
    }
}
