using UnityEngine;
using System.Collections;

public class ClockUI : MonoBehaviour {

    public GameObject clockHand;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame

    public void SetRotation(float angle)
    {
        float current = clockHand.transform.rotation.z;
        clockHand.transform.Rotate(0, 0, angle - current);
    }
}
