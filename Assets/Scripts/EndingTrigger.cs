using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Ray rayToObject = new Ray (Camera.main.transform.position, transform.position - Camera.main.transform.position);
		RaycastHit rayHit = new RaycastHit ();

		if (Physics.Raycast (rayToObject, out rayHit, 50f)) {
			if (rayHit.transform.Equals (transform)) {
				if (Vector3.Angle (Camera.main.transform.forward, transform.position - Camera.main.transform.position) <= 30f) {
					Ending();
				}
			}
		}
	}

	void Ending(){
		Debug.Log ("YAY");
	}

}
