using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerOpen : MonoBehaviour {

	//set up with raycast

	// end point for Lerp
	Vector3 end;

	bool drawerOpening = false;

	void Start () {
		end = transform.position + Vector3.forward * 2.5f;
	}

	void Update () {
		if (drawerOpening) {
			OpenDrawer ();
		}
		//Call OpenDrawer if player clicks on drawer, but right now just do it with Q for debugging purposes
		if (Input.GetKeyDown(KeyCode.Q)) {
			drawerOpening = true;
		}
	}

	void OpenDrawer () {
//		float dist = Vector3.Distance(transform.position, end);
//		if (dist < 0.01f) {
//			drawerOpening = false;
//		}
//		transform.position = Vector3.Lerp (transform.position, end, Time.deltaTime);
		transform.localPosition = new Vector3 (-0.1829332f, -0.2351983f, 0.013f);
	}
}
