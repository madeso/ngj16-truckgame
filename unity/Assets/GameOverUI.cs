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
        Color losingPlayerColor = player.GetComponent<TruckController>().Controller.color;
        string winningPlayer = (losingPlayerColor.r > losingPlayerColor.b) ? "Blue" : "Red";
        gameOverText.text = winningPlayer +" player wins!\n\nPress start button to restart";
        gameOverText.gameObject.SetActive(true);
        canRestartGame = true;
    }
}
