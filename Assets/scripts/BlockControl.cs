using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour
{

    private bool wasAboveLine = false;
	private CountdownClock cntdwnclk;
    private CursorControl cursor;
    private SpriteRenderer spriteRenderer;

    void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start ()
    {
		cntdwnclk = transform.parent.GetComponentInChildren<CountdownClock>();
        cursor = transform.parent.GetComponent<CursorControl>();
        spriteRenderer.color = cursor.playerColor;
    }

    void FixedUpdate ()
    {
		// TODO: check if block is above win line (within tolerance) and report on state change
		if (transform.position.y >= GameManagerScript.winHeight && !wasAboveLine) {
			Debug.Log("I am above the line, which is: " + GameManagerScript.winHeight + " I am: " + transform.position.y);
			wasAboveLine = true;
			cntdwnclk.ReportAboveLine ();
		} else if (transform.position.y <= GameManagerScript.winHeight && wasAboveLine) {
			Debug.Log("Don't do drugs kids");
			wasAboveLine = false;
			cntdwnclk.ReportBelowLine ();
		}

    }
}
