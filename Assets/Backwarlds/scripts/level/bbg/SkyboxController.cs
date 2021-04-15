using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Transform skybox1;
    public Transform skybox2;
    private float wrapThreshold;
    private Vector3 start;
    public Rigidbody2D player;

	// Use this for initialization
	void Start ()
    {
        wrapThreshold = skybox1.position.x - (skybox2.position.x - skybox1.position.x);
        start = skybox2.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        skybox1.position = new Vector2(skybox1.position.x - player.velocity.x * Time.deltaTime * 0.05f, skybox1.position.y);
        skybox2.position = new Vector2(skybox2.position.x - player.velocity.x * Time.deltaTime * 0.05f, skybox2.position.y);
        if (skybox1.position.x <= wrapThreshold)
        {
            skybox1.position = new Vector2(start.x - 0.1f, start.y);
        }
        else if (skybox2.position.x <= wrapThreshold)
        {
            skybox2.position = new Vector2(start.x, start.y);
            skybox1.position = new Vector2(skybox1.position.x + 0.1f, skybox1.position.y);
        }
    }
}
