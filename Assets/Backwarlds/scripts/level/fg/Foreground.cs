using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Foreground : MonoBehaviour {

    public Collider2D foreground;
    private bool levelstate;
    private string[] layerOptions;

	// Use this for initialization
	void Start ()
    {
        levelstate = true;
	}

    // Update is called once per frame
    public void Switch()
    {
        levelstate = !levelstate;
        Debug.Log("State swapped");
        foreground.enabled = levelstate;
        Transform location = GetComponent<Transform>();
        location.position = new Vector3(location.position.x, location.position.y, System.Convert.ToSingle(!levelstate) * 2f);
        GetComponent<TilemapRenderer>().sortingOrder = System.Convert.ToInt32(levelstate) * 2;
    }
}
