using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {

    public static int winHeight = 16;
    public static int lineBuffer = 1;

    public GameObject player1;
    public GameObject player2;
    public GameObject startMenu;
    public GameObject finishMenu;
    public GameObject winZone;


    public Queue player1Queue = new Queue();
    public Queue player2Queue = new Queue();

    public int queueLength = 4;

    private List<string> stoneBlocks;

    void Awake ()
    {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
    }

    void Start ()
    {
        // stoneBlocks = new List<string>{"stone/StoneColumn", "stone/StoneCircle", "stone/StoneLgTriangle", "stone/StoneTriangle", "stone/StoneSquare", "stone/StoneFlat"};
        stoneBlocks = new List<string>{"stone/StoneColumn", "stone/StoneSquare", "stone/StoneFlat"};
        startMenu.SetActive(true);
        finishMenu.SetActive(false);
        player1.SetActive (false);
        player2.SetActive (false);
        winZone.transform.position = new Vector3(0,
            winHeight + 2,
            winZone.transform.position.z);
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
        Debug.Log(winner + " won the game!");
        player1.SetActive (true);
        player2.SetActive (true);
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
