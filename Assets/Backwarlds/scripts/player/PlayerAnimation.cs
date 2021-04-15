using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator _anim;
	private Player _player;

	// Use this for initialization
	void Start () 
	{
		_anim = GetComponent<Animator>();
		_player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		var playerState = _player.GetPlayerState();
		if (playerState == PlayerState.Walking) 
		{
			_anim.SetBool("isWalking", true);
			_anim.SetBool("isJumping", false);
		} 
		if (playerState == PlayerState.Jumping) {
			_anim.SetBool("isWalking", false);
			_anim.SetBool("isJumping", true);
		} 
		if (playerState == PlayerState.Idling) {
			_anim.SetBool("isWalking", false);
			_anim.SetBool("isJumping", false);
		}
	}
}
