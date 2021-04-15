using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private bool gameOver = true;

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject playerShadow;
	private UIManager _uiManager;

	// Use this for initialization
	void Start () {
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				beginGame();
			}
		}
	}

	public void beginGame() {
		gameOver = false;
		_uiManager.hideTitle();
		// Instantiate(player, new Vector3(-12.25f, 1.84f, 0), Quaternion.identity);
		// Instantiate(playerShadow, new Vector3(-4.65f, -.43f, 6), Quaternion.identity);
	}

	public void endGame() {
		gameOver = true;
		_uiManager.showTitle();
	}

	public bool isGameOver() {
		return gameOver;
	}
}
