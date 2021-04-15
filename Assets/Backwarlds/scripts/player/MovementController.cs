using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public enum PlayerStates
{
    
}

public class MovementController : MonoBehaviour
{
    public Player player;
    public bool inputState;
    public PostProcessingProfile blueTint;
    public PostProcessingProfile redTint;
    private PostProcessingProfile curr;

	// Use this for initialization
	void Start()
    {
        player = GetComponent<Player>();
        curr = blueTint;
        GameObject.Find("Main Camera").GetComponent<PostProcessingBehaviour>().profile = curr;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inputState)
        {
            player.SetState();
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.MoveRight();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player.MoveLeft();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                player.Jump();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && GameObject.Find("Player") != null)
            {
                Switch();
            }
        }
    }

    void Switch()
    {
        GameObject.Find("Foreground").GetComponent<Foreground>().Switch();
        GameObject.Find("Background").GetComponent<Background>().Switch();
        GameObject.Find("Nobody").GetComponent<Nobody>().Switch();
        if ( curr == blueTint)
        {
            curr = redTint;
        }
        else
        {
            curr = blueTint;
        }
        GameObject.Find("Main Camera").GetComponent<PostProcessingBehaviour>().profile = curr;
    }
}
