using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

	float upDownLook = 0f;

	// Update is called once per frame
	void Update () {

		float mouseY = Input.GetAxis ("Mouse Y");
		//clamp/constrain the X angle so we can't look too far up or down
		upDownLook -= mouseY;
		upDownLook = Mathf.Clamp (upDownLook, -80f, 80f); //constrain look 80 degrees

		//unroll the camera
		transform.eulerAngles = new Vector3( upDownLook * 3f, transform.eulerAngles.y, 0f);
	}
}
