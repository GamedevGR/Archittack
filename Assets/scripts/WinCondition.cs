using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

    public static int winHeight = 18;
    public static int lineBuffer = 1;

    void Start ()
    {

    }

    void Update ()
    {
        Debug.DrawLine(new Vector3(-20, winHeight, 0), new Vector3(20, winHeight, 0), Color.green);
        Debug.DrawLine(new Vector3(-20, winHeight - lineBuffer, 0), new Vector3(20, winHeight - lineBuffer, 0), Color.red);
    }

    public static void GameOver(string winner)
    {
        Debug.Log(winner + " won the game!");
    }
}
