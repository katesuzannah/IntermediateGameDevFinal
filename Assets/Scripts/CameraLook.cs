using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLook : MonoBehaviour {

	float upDownLook = 0f;
	public Collider currentlyHeld;
	public Collider emptyHold;
	Vector3 whereAt;
	public GameObject laptop; 
	public GameObject laptopPopUpCanvas; 

	void Start(){
		currentlyHeld = emptyHold;
		whereAt = emptyHold.GetComponent<Transform> ().position;
	}

	// Update is called once per frame
	void Update () {
		float mouseY = Input.GetAxis ("Mouse Y");
		//clamp/constrain the X angle so we can't look too far up or down
		upDownLook -= mouseY;
		upDownLook = Mathf.Clamp (upDownLook, -26.6f, 26.6f); //constrain look 80 degrees

		//unroll the camera
		transform.eulerAngles = new Vector3( upDownLook * 3f, transform.eulerAngles.y, 0f);

		//initialize a Ray
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);

		//initialize rayHit
		RaycastHit rayHit = new RaycastHit();

		if (currentlyHeld.tag != "book") {
			//shoot raycast
			if (Physics.Raycast (ray, out rayHit, 5f)) {
                //pickup on click
                if (Input.GetMouseButton (0)) {
					currentlyHeld = rayHit.collider; //remember what we hit
					if (currentlyHeld.tag == "book")
                    {
                        //keep it in front of you
                        currentlyHeld.transform.parent = Camera.main.transform;
						currentlyHeld.GetComponent<Rigidbody> ().useGravity = false;
						whereAt = currentlyHeld.GetComponent<Transform> ().localPosition;
					} else if (currentlyHeld.tag == "laptop") {
						//clicks on laptop
						laptopPopUpCanvas.SetActive (true);
						Cursor.visible = true;
						Cursor.lockState = CursorLockMode.None;
					}
				}
            }
		} else {
			currentlyHeld.GetComponent<Transform> ().localPosition = whereAt;
            //drop item
            if (Input.GetMouseButtonUp (0)) {
                if (currentlyHeld.tag == "book")
                {
                    currentlyHeld.transform.SetParent (null);
					currentlyHeld.GetComponent<Rigidbody> ().useGravity = true;
					currentlyHeld = emptyHold;
				}
			}
		}
	}

}
