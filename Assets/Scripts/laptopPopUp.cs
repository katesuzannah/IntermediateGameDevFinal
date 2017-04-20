using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class laptopPopUp : MonoBehaviour {
	public GameObject laptopPopUpCanvas;
	public Button exitButton; 
	//public GameObject character;
	//public Camera mainCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.Mouse0)) {
//			laptopPopUpCanvas.SetActive (true);
//			Cursor.visible = true;
//			Cursor.lockState = CursorLockMode.None;
//			//character.GetComponent<PlayerMove> ().enabled = false; 
//			//mainCam.GetComponent<CameraLook> ().enabled = false;
//		}
	}

//	public void OnClickButton (string choice){
//		if (choice == "exit") {
//			laptopPopUpCanvas.SetActive (false);
//			//character.GetComponent<PlayerMove> ().enabled = true; 
//			//mainCam.GetComponent<CameraLook> ().enabled = true; 
//		}
//	}

	public void TurnOffCanvas(){
		laptopPopUpCanvas.SetActive (false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		Camera.main.GetComponent<CameraLook> ().looking = true;
	}

}
