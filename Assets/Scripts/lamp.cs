using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : MonoBehaviour {

	public Material litBulb;
	public Material unlitBulb;
	public Renderer lightbulbRenderer;
	bool lightOn = false;
	public GameObject spotlight;
	public static int flickers;

	void Start () {
		flickers = 0;
	}

	// Update is called once per frame
	void Update () {
		//initialize a Ray
//		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
//		//initialize rayHit
//		RaycastHit rayHit = new RaycastHit();
//		if (Physics.Raycast (ray, out rayHit, 10f)) {
//			if (rayHit.collider.tag == "lightswitch" && Input.GetMouseButtonDown(0)) {
//				switchOn ();
//			}
//		}
		if (Input.GetKeyDown(KeyCode.L)) {
			switchOn ();
		}
	}

	public void switchOn () {
		if (!lightOn) {
			lightbulbRenderer.material = litBulb;
			spotlight.SetActive (true);
			lightOn = true;
			flickers++;
		}
		else if (lightOn) {
			lightbulbRenderer.material = unlitBulb;
			spotlight.SetActive (false);
			lightOn = false;
			flickers++;
		}
	}
}
