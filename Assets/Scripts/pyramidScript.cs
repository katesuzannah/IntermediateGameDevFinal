using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pyramidScript : MonoBehaviour {

	public GameObject bot;
	bool instantiate = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "ceiling" && instantiate) {
			GameObject botman = Instantiate (bot);
            GameManager.Instance.illuminatiMan = botman.transform;
			instantiate = false;
		}
	}
}
