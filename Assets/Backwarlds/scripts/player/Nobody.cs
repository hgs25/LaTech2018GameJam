using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nobody : MonoBehaviour {


    private bool levelstate;
    public PolygonCollider2D nobody;
	// Use this for initialization
	void Start ()
    {
        levelstate = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collison)
    {
        foreach (ContactPoint2D point in collison.contacts)
        {
            Debug.Log(point.collider.name);
            if (point.collider.name == "Player")
            {
                GameObject.Find("Player").GetComponent<Player>().playerDeath();
            }
        }
    }

    public void Switch()
    {
        levelstate = !levelstate;
        Debug.Log("State swapped");
        nobody.enabled = levelstate;
        Transform location = GetComponent<Transform>();
        location.position = new Vector3(location.position.x, location.position.y, System.Convert.ToSingle(!levelstate) * 2f);
        GetComponent<SpriteRenderer>().sortingOrder = System.Convert.ToInt32(levelstate) * 2;
        if (!levelstate)
        {
            GetComponent<Rigidbody2D>().Sleep();
        }
        else
        {
            GetComponent<Rigidbody2D>().WakeUp();
        }
    }
}
