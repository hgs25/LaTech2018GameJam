using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    Idling,
    Walking,
    Jumping,
}

public class Player : MonoBehaviour
{

    public Transform player;
    public Transform playershadow;
    public PlayerState playerState;
    public GameObject canvas;
    private Rigidbody2D rbody;
    private AudioSource _jumpSound;
    [SerializeField] private GameObject confetti;


	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Transform>();
        playerState = PlayerState.Idling;
        rbody = GetComponent<Rigidbody2D>();
        _jumpSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        playershadow.position = new Vector3(player.position.x, player.position.y, 2f);

        if (playerState == PlayerState.Idling && Mathf.Abs(rbody.velocity.x) != 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x - (float)(0.2 * rbody.velocity.x / Mathf.Abs(rbody.velocity.x)), rbody.velocity.y);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision");
        //foreach (ContactPoint2D contact in collision.contacts)
        //{
        //    if ((contact.collider.CompareTag("Foreground") || contact.collider.name == "background") && playerState == PlayerState.Jumping)
        //    {
        //        playerState = PlayerState.Idling;
        //    }
        //}
    }

    void LateUpdate()
    {
        if (player.position.y <= -8f)
        {
            playerDeath();
        }
    }

    public void MoveRight()
    {
        rbody.velocity = new Vector2(Mathf.Min(rbody.velocity.x + 0.2f, 7f), rbody.velocity.y);
        player.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        playershadow.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    public void MoveLeft()
    {
        rbody.velocity = new Vector2(Mathf.Max(rbody.velocity.x - 0.2f, -7f), rbody.velocity.y);
        player.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        playershadow.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
    }

    public void Jump()
    {
        _jumpSound.Play();
        if (!GetAirState())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4.75f), ForceMode2D.Impulse);
        }
    }

    public void SetState()
    {
        if (GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            playerState = PlayerState.Jumping;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerState = PlayerState.Walking;
        }
        else
        {
            playerState = PlayerState.Idling;
        }
    }

    public PlayerState GetPlayerState() {
        return playerState;
    }

    private bool GetAirState()
    {
        return playerState == PlayerState.Jumping;
    }

    public void playerDeath() {
        Instantiate(confetti, transform.position, Quaternion.identity);
        gameObject.GetComponent<SpriteRenderer>().enabled = false; // hide player
        playershadow.GetComponent<SpriteRenderer>().enabled = false; // hide player shadow
        StartCoroutine(SceneReset());
    }

    IEnumerator SceneReset() {
        Debug.Log("begin coroutine");
        yield return new WaitForSeconds(3);
        Debug.Log("reload scene");
        SceneManager.LoadScene("game");
    }

    // void OnTriggerEnter2D (Collider2D other) {
	// 	if (other.tag == "Enemy") {
	// 		playerDeath();
	// 	}
	// }
}
