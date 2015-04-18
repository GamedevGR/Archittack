using UnityEngine;
using System.Collections;

public class CountdownClock : MonoBehaviour {

    public int numAboveLine;
    public float maxTime;
    public float currentTime;
	public string blah;

    // Use this for initialization
    void Start ()
    {
        numAboveLine = 0;
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update ()
    {
        // TODO: decrement currentTime if numAboveLine > 0

        // TODO: if current time <= 0 report winner to game manager
    }

    public void ResetTimer()
    {
        // TODO: reset the timer (call from cursor)
    }

    public void ReportAboveLine()
    {
        // TODO: implement
    }

    public void ReportBelowLine()
    {
        // TODO: implement
    }
}
