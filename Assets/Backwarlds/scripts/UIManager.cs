using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject canvas;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showTitle() {
		canvas.SetActive(true);
        GameObject.Find("Player").GetComponent<MovementController>().inputState = false;
	}

	public void hideTitle() {
		canvas.SetActive(false);
        GameObject.Find("Player").GetComponent<MovementController>().inputState = true;
	}
}
