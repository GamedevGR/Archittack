using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QueueUI : MonoBehaviour {
	public int playerID;

	public Image image1;
	public Image image2;
	public Image image3;
	public Image image4;

	private Dictionary<string, Sprite> spriteLookup = new Dictionary<string, Sprite>();

	private object[] container;

	GameManagerScript gameManager;


	void Awake () {
		Sprite[] sprites = Resources.LoadAll<Sprite> ("blocks") as Sprite[];
		foreach (Sprite s in sprites) {
			spriteLookup.Add (s.name, s);
			Debug.Log("Registered: " + s.name);
		}
	}

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
	}

	// Update is called once per frame
	void Update () {
		Queue localQueue;
		if (playerID == 1) {
			localQueue = gameManager.player1Queue;
		} else {
			localQueue = gameManager.player2Queue;
		}

		if (localQueue.Count == gameManager.queueLength) {
			container = localQueue.ToArray();
			image1.sprite = spriteLookup[(container[0] as string).Split('/')[1]];
			image2.sprite = spriteLookup[(container[1] as string).Split('/')[1]];
			image3.sprite = spriteLookup[(container[2] as string).Split('/')[1]];
			image4.sprite = spriteLookup[(container[3] as string).Split('/')[1]];
		}

	}
}
