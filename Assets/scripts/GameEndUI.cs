using UnityEngine;
using System.Collections;

public class GameEndUI : MonoBehaviour {

    private GameManagerScript gameManager;
    private string selectButton = "Select";

    void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update ()
    {
        if (Input.GetButton(selectButton)) {
            this.RestartButton();
        }
    }

    public void RestartButton()
    {
        gameManager.RestartGame();
    }
}
