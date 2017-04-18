using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminatiBotAnimationScript : MonoBehaviour {

	Animator myAnimator;
	float timer;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
	}

	void Attack () {
		myAnimator.SetBool ("isWalking", true);
		timer += Time.deltaTime;
		if (timer > 2f) {
			myAnimator.SetBool ("isWalking", false);
			myAnimator.SetBool ("isStabbing", true);
		}
		//Move to a gameover screen probably
	}
}
