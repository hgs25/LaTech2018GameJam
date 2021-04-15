using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Background : MonoBehaviour {

    public Collider2D background;
    private bool levelstate;
	// Use this for initialization
    void Awake()
    {
        background.enabled = false;
    }

	void Start()
    {
        levelstate = false;
	}

    // Update is called once per frame
    public void Switch()
    {
        levelstate = !levelstate;
        Debug.Log("State swapped");
        background.enabled = levelstate;
        Transform location = GetComponent<Transform>();
        location.position = new Vector3(location.position.x, location.position.y, System.Convert.ToSingle(!levelstate) * 2f);
        GetComponent<TilemapRenderer>().sortingOrder = System.Convert.ToInt32(levelstate) * 2;
    }
}
