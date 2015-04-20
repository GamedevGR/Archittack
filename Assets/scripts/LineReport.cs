using UnityEngine;
using System.Collections;

public class LineReport : MonoBehaviour {

    private bool wasAboveLine = false;
    private CountdownClock countdownClock;

	void Start ()
    {
        countdownClock = transform.parent.parent.GetComponentInChildren<CountdownClock>();
	}

    void FixedUpdate ()
    {
        // TODO: check if block is above win line (within tolerance) and report on state change
        if (transform.position.y >= GameManagerScript.winHeight && !wasAboveLine) {
            Debug.Log("I am above the line, which is: " + GameManagerScript.winHeight + " I am: " + transform.position.y);
            wasAboveLine = true;
            countdownClock.ReportAboveLine ();
        } else if (transform.position.y <= GameManagerScript.winHeight && wasAboveLine) {
            Debug.Log("Don't do drugs kids");
            wasAboveLine = false;
            countdownClock.ReportBelowLine ();
        }

    }
}
