using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour
{

    private bool wasAboveLine = false;
	private CountdownClock cntdwnclk;

    void Awake ()
    {

    }

    void Start ()
    {
		cntdwnclk = transform.parent.GetComponentInChildren<CountdownClock>();
    }

    void FixedUpdate ()
    {
		// TODO: check if block is above win line (within tolerance) and report on state change
		if (transform.position.y >= WinCondition.winHeight && !wasAboveLine) {
			Debug.Log("I am above the line, which is: " + WinCondition.winHeight + " I am: " + transform.position.y);
			wasAboveLine = true;
			cntdwnclk.ReportAboveLine ();
		} else if (transform.position.y <= WinCondition.winHeight && wasAboveLine) {
			Debug.Log("Don't do drugs kids");
			wasAboveLine = false;
			cntdwnclk.ReportBelowLine ();
		}

    }
}
