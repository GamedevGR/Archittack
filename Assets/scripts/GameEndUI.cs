using UnityEngine;
using System.Collections;

public class GameEndUI : MonoBehaviour {

    private GameManagerScript gameManager;

    void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    public void RestartButton()
    {
        gameManager.RestartGame();
    }
}
