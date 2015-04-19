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
    private GameObject cursor;
    private CountdownClock countdownClock;

    void Awake () {
        // TODO: get a reference to the countdown clock
		// stoneBlocks = new List<string>{"stone/StoneColumn", "stone/StoneCircle", "stone/StoneLgTriangle", "stone/StoneTriangle", "stone/StoneSquare", "stone/StoneFlat"};
		stoneBlocks = new List<string>{"stone/StoneColumn", "stone/StoneSquare", "stone/StoneFlat"};
        cursor = transform.FindChild("cursor").gameObject;
        body = cursor.GetComponent<Rigidbody2D>() as Rigidbody2D;
        spriteRenderer = this.GetComponent<SpriteRenderer>() as SpriteRenderer;
        countdownClock = transform.GetComponentInChildren<CountdownClock>();

        if (playerNumber != 1) {
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
            dropButton = "Drop2";
            playerColor = Color.red;
            cursor.GetComponent<SpriteRenderer>().color = playerColor;
        } else {
            playerColor = Color.blue;
            cursor.GetComponent<SpriteRenderer>().color = playerColor;
        }
    }

    void Start ()
    {
    }

    void Update ()
    {
#if UNITY_EDITOR
        float pX = cursor.transform.parent.position.x;
        float pY = cursor.transform.parent.position.y;
        Debug.DrawLine(new Vector3(pX + topLeftBound.x, pY + bottomRightBound.y, 0), new Vector3(pX + bottomRightBound.x, pY + bottomRightBound.y, 0), playerColor);
        Debug.DrawLine(new Vector3(pX + topLeftBound.x, pY + topLeftBound.y, 0), new Vector3(pX + bottomRightBound.x, pY + topLeftBound.y, 0), playerColor);
        Debug.DrawLine(new Vector3(pX + bottomRightBound.x, pY + bottomRightBound.y, 0), new Vector3(pX + bottomRightBound.x, pY + topLeftBound.y, 0), playerColor);
        Debug.DrawLine(new Vector3(pX + topLeftBound.x, pY + bottomRightBound.y, 0), new Vector3(pX + topLeftBound.x, pY + topLeftBound.y, 0), playerColor);
#endif
        // Cursor location handling
        float hSpeed = Input.GetAxis(horizontalAxis);
        float vSpeed = Input.GetAxis(verticalAxis);

        body.velocity = new Vector2 (hSpeed * maxSpeed, vSpeed * maxSpeed);

        float newX = cursor.transform.localPosition.x;
        float newY = cursor.transform.localPosition.y;

        // bound the cursor to the box
        if (cursor.transform.localPosition.x <= topLeftBound.x) {
            newX = topLeftBound.x;
        } else if (cursor.transform.localPosition.x >= bottomRightBound.x) {
            newX = bottomRightBound.x;
        }
        if (cursor.transform.localPosition.y >= topLeftBound.y) {
            newY = topLeftBound.y;
        } else if(cursor.transform.localPosition.y <= bottomRightBound.y) {
            newY = bottomRightBound.y;
        }
        cursor.transform.localPosition = new Vector2 (newX, newY);

        // Droping blocks
        if (Input.GetButtonDown(dropButton)) {
            // TODO: delay between drops
            // TODO: reset countdown clock
			countdownClock.ResetTimer();

            int r = Random.Range(0, stoneBlocks.Count);
            GameObject block = Instantiate(Resources.Load(stoneBlocks[r])) as GameObject;
            block.transform.position = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
            block.transform.SetParent(transform);
        }
    }
}
