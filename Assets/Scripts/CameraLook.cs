using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

	float upDownLook = 0f;
	public Collider currentlyHeld;

	// Update is called once per frame
	void Update () {

		float mouseY = Input.GetAxis ("Mouse Y");
		//clamp/constrain the X angle so we can't look too far up or down
		upDownLook -= mouseY;
		upDownLook = Mathf.Clamp (upDownLook, -80f, 80f); //constrain look 80 degrees

		//unroll the camera
		transform.eulerAngles = new Vector3( upDownLook * 3f, transform.eulerAngles.y, 0f);

		//initialize a Ray
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);

		//initialize rayHit
		RaycastHit rayHit = new RaycastHit();

		//shoot raycast
		if (Physics.Raycast (ray, out rayHit, 5f)) {
			//pickup on click
			if (Input.GetMouseButton (0)) {
				currentlyHeld = rayHit.collider; //remember what we hit
				currentlyHeld.transform.parent = Camera.main.transform;
			}

			if (Input.GetMouseButtonUp (0)) {
				currentlyHeld.transform.SetParent (null);
			}
		}
	}
}
