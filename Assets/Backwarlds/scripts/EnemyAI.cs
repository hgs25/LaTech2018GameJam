using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.otherCollider.tag == "Player") {
			Player player = other.otherCollider.GetComponent<Player>();
			if (player != null) {
				player.playerDeath();
			}
		}
	}
}
