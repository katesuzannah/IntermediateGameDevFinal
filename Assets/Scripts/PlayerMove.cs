using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	float upDownLook = 0f;

	// Use this for initialization
	void Start () {
		
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {
		//get mouse input data
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		//rotate camera based on mouse movement
		transform.Rotate(0f, mouseX * 3f, 0f);

		//clamp/constrain the X angle so we can't look too far up or down
		upDownLook -= mouseY;
		upDownLook = Mathf.Clamp (upDownLook, -80f, 80f); //constrain look 80 degrees

		//unroll the camera
		transform.eulerAngles = new Vector3( upDownLook* 3f, transform.eulerAngles.y, 0f);

	}
}
