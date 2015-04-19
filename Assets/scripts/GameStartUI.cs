using UnityEngine;
using System.Collections;

public class GameStartUI : MonoBehaviour {

    private GameManagerScript gameManager;

	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
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
