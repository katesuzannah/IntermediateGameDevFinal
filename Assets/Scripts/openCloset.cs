using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloset : MonoBehaviour {

	bool open;

	// Use this for initialization
	void Start () {
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			openClosetDoor ();
		}
	}

	void openClosetDoor () {
		if ((name == "leftDoor" && open == false) || (name == "rightDoor" && open)) {
			transform.Rotate (0f, 150f, 0f);
			if (open) {
				open = false;
			}
			else {
				open = true;
			}
		}
		else if ((name == "rightDoor" && open == false) || (name == "leftDoor" && open))  {
			transform.Rotate (0f, -150f, 0f);
			if (open) {
				open = false;
			}
			else {
				open = true;
			}
		}
	}
}
