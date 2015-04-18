using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    private List<string> stoneBlocks;
    private Color playerColor;

    void Awake () {
        // TODO: get a reference to the countdown clock
        body = this.GetComponent<Rigidbody2D>() as Rigidbody2D;
        spriteRenderer = this.GetComponent<SpriteRenderer>() as SpriteRenderer;
		//stoneBlocks = new List<string>{"stone/StoneColumn", "stone/StoneCircle", "stone/StoneLgTriangle", "stone/StoneTriangle", "stone/StoneSquare", "stone/StoneFlat"};
		stoneBlocks = new List<string>{"stone/StoneColumn", "stone/StoneSquare", "stone/StoneFlat"};

		if (playerNumber != 1) {
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
            dropButton = "Drop2";
            playerColor = Color.red;
            spriteRenderer.color = playerColor;
        } else {
            playerColor = Color.blue;
            spriteRenderer.color = playerColor;
        }
    }

    void Start ()
    {

    }

    void Update ()
    {
#if UNITY_EDITOR
        float pX = transform.parent.position.x;
        float pY = transform.parent.position.y;
        Debug.DrawLine(new Vector3(pX + topLeftBound.x, pY + bottomRightBound.y, 0), new Vector3(pX + bottomRightBound.x, pY + bottomRightBound.y, 0), playerColor);
        Debug.DrawLine(new Vector3(pX + topLeftBound.x, pY + topLeftBound.y, 0), new Vector3(pX + bottomRightBound.x, pY + topLeftBound.y, 0), playerColor);
        Debug.DrawLine(new Vector3(pX + bottomRightBound.x, pY + bottomRightBound.y, 0), new Vector3(pX + bottomRightBound.x, pY + topLeftBound.y, 0), playerColor);
        Debug.DrawLine(new Vector3(pX + topLeftBound.x, pY + bottomRightBound.y, 0), new Vector3(pX + topLeftBound.x, pY + topLeftBound.y, 0), playerColor);
#endif
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
            // TODO: delay between drops
            // TODO: reset countdown clock
			transform.parent.GetComponentInChildren<CountdownClock>().ResetTimer();

            int r = Random.Range(0, stoneBlocks.Count);
            GameObject block = Instantiate(Resources.Load(stoneBlocks[r])) as GameObject;
            block.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
