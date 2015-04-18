using UnityEngine;
using System.Collections;

public class CountdownClock : MonoBehaviour {

    public int numAboveLine;
    public float maxTime;
    public float currentTime;
	public string blah;

    public ClockUI clockUI;

    // Use this for initialization
    void Start ()
    {
        numAboveLine = 0;
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update ()
    {
		if (numAboveLine > 0) {
			currentTime -= Time.deltaTime;
		} else {
			ResetTimer ();
		}

        float angle = -(1 - currentTime / maxTime) * 360;
        clockUI.SetRotation(angle);

		if (currentTime < 0) {
            currentTime = 0;
			WinCondition.GameOver(transform.parent.name);
		}
    }

    public void ResetTimer()
    {
		currentTime = maxTime;
    }

    public void ReportAboveLine()
    {
		numAboveLine ++;
    }

    public void ReportBelowLine()
    {
		numAboveLine --;
	}
}
