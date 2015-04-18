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
    private SpriteRenderer spriteRenderer;

    void Awake () {
        body = this.GetComponent<Rigidbody2D>() as Rigidbody2D;
        spriteRenderer = this.GetComponent<SpriteRenderer>() as SpriteRenderer;
        if (playerNumber != 1) {
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
            dropButton = "Drop2";
            spriteRenderer.color = new Color(1, 0, 0);
        } else {
            spriteRenderer.color = new Color(0, 0, 1);
        }
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        // Cursor location handling
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

        // Droping blocks
        if (Input.GetButtonDown(dropButton)) {
            GameObject block = Instantiate(Resources.Load("square_1x1_block")) as GameObject;
            block.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
