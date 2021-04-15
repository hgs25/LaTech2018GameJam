using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject focus;
    Vector2 focuspoint;

	// Use this for initialization
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        focuspoint = focus.GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(focuspoint.x + 5f, Mathf.Max(1f, focuspoint.y + 0.75f), -3f);
    }
}
