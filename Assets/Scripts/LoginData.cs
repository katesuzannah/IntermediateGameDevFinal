using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginData : MonoBehaviour {

	public Text nameInput;
	public Text passInput;
	public InputField passField;
	public static string username;
	public static string password;


	
	// Update is called once per frame
	void Update () {
		username = nameInput.text;
		password = passField.text;

//		while (passInput.text.Length > password.Length) {
//			password += passInput.text.ToCharArray () [passInput.text.Length - 1];
//		}
//
//		while (passInput.text.Length < password.Length) {
//			if (password.Length > 1) {
//				password = password.Substring (0, password.Length - 2);
//			} else {
//				password = "";
//			}
//		}
//
//		stars = "";
//
//		for (int i = 0; i < password.Length; i++) {
//			stars += "*";
//		}
//
//		passInput.text = stars;
	}

	public void gotoJoshTest(){
		if ((password != "") && (nameInput.text != "")) {
			SceneManager.LoadScene ("grantLevel");
		}
	}
}
