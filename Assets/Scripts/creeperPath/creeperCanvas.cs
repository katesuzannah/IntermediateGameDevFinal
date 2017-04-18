using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creeperCanvas : MonoBehaviour {

	public Text usernameText;
	public Text passwordText; 

	// Use this for initialization
	void Start () {
		usernameText.text = LoginData.username;
		passwordText.text = LoginData.password;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
