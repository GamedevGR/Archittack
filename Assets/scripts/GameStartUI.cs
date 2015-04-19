using UnityEngine;
using System.Collections;

public class GameStartUI : MonoBehaviour {

    private GameManagerScript gameManager;
    private string startButton = "Start";

	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}

    void Update ()
    {
        if (Input.GetButton(startButton)) {
            this.TwoPlayerButton();
        }
    }

    public void OnePlayerButton()
    {
        Debug.Log("What, don't have any friends?");
    }

    public void TwoPlayerButton()
    {
        gameManager.StartTwoPlayerGame();
    }

    public void SettingsButton()
    {
        Debug.Log("Psssh, like we have settings...");
    }
}
