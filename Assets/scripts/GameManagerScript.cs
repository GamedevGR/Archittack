using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {

    public static int winHeight = 16;
    public static int lineBuffer = 1;

    public GameObject player1;
    public GameObject player2;
    public GameObject startMenu;
    public GameObject finishMenu;
    public GameObject ground;

    public Sprite player1Win;
    public Sprite player1Lose;
    public Sprite player2Win;
    public Sprite player2Lose;

    public Image player1Status;
    public Image player2Status;

    public Queue player1Queue = new Queue();
    public Queue player2Queue = new Queue();

    public int queueLength = 4;

    private List<string> stoneBlocks;
    private bool gameIsOver = false;

    void Awake ()
    {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        ground = GameObject.Find("ground");

		stoneBlocks = new List<string>{"stone/StoneColumn",
            "stone/StoneCircle",
            "stone/StoneLgTriangle",
            "stone/StoneTriangle",
            "stone/StoneSquare","stone/StoneSquare","stone/StoneSquare","stone/StoneSquare","stone/StoneSquare","stone/StoneSquare","stone/StoneSquare",
            "stone/StoneFlat","stone/StoneFlat","stone/StoneFlat","stone/StoneFlat","stone/StoneFlat",
            "bouncy/BouncySquare",
            "wood/WoodPlank", "wood/WoodPlank", "wood/WoodPlank",
            "wood/WoodSquare", "wood/WoodSquare", "wood/WoodSquare",
            "metal/MetalSquare"
        };

		for (int i = 0; i < queueLength; i++) {
			player1Queue.Enqueue (NextPieceForQueue ());
			player2Queue.Enqueue (NextPieceForQueue ());
		}
	}

	void Start ()
	{
        startMenu.SetActive(true);
        finishMenu.SetActive(false);
        player1.SetActive (false);
        player2.SetActive (false);
    }

    void Update ()
    {
        Debug.DrawLine(new Vector3(-20, winHeight, 0), new Vector3(20, winHeight, 0), Color.green);
        Debug.DrawLine(new Vector3(-20, winHeight - lineBuffer, 0), new Vector3(20, winHeight - lineBuffer, 0), Color.red);

        if(player1Queue.Count < queueLength) {
            player1Queue.Enqueue(NextPieceForQueue());
        }
        if(player2Queue.Count < queueLength) {
            player2Queue.Enqueue(NextPieceForQueue());
        }
    }

    public void GameOver(string winner)
    {
        if (gameIsOver) {
            return;
        }

        gameIsOver = true;

        if (winner == "player1") {
            player1Status.sprite = player1Win;
            player2Status.sprite = player2Lose;
        } else {
            player1Status.sprite = player1Lose;
            player2Status.sprite = player2Win;
        }

        Debug.Log(winner + " won the game!");
        player1.GetComponent<CursorControl>().enabled = false;
        player2.GetComponent<CursorControl>().enabled = false;
        ground.SetActive(false);
        finishMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Reloading scene");
        Application.LoadLevel(Application.loadedLevel);
    }

    public void StartTwoPlayerGame()
    {
        Debug.Log("Starting Two Player Game");
        player1.SetActive (true);
        player2.SetActive (true);
        startMenu.SetActive(false);
    }

    private string NextPieceForQueue()
    {
        int r = Random.Range(0, stoneBlocks.Count);
        return stoneBlocks[r];
    }
}
