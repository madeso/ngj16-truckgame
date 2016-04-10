using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public Text gameOverText;
    private bool canRestartGame = false;

	// Use this for initialization
	void Start () {
        Health.OnPlayerDied += OnPlayerDied;
	}

    void OnDestroy () {
        Health.OnPlayerDied -= OnPlayerDied;
    }
	
	// Update is called once per frame
	void Update () {
        if (canRestartGame && InputManager.ActiveDevice.MenuWasPressed)
        {
            SceneManager.LoadScene("Main");
        }
	}

    void OnPlayerDied(GameObject player) {
        int winningPlayer = (player.GetComponent<TruckController>().Controller.player == 0) ? 2 : 1;
        gameOverText.text = "Player "+ winningPlayer +" Wins!\n\nPress start button to restart";
        gameOverText.gameObject.SetActive(true);
        canRestartGame = true;
    }
}
