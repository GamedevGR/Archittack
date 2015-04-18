using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

    public static int winHeight;

    void Start ()
    {

    }

    void Update ()
    {

    }

    public void GameOver(string winner)
    {
        Debug.Log(winner + " won the game!");
    }
}
