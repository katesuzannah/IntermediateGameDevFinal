using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class creeperPaperPopUp : MonoBehaviour {

	public GameObject creeperPaperCanvas;
	public Button exitPaper; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOffCanvas(){
		creeperPaperCanvas.SetActive (false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}


}
