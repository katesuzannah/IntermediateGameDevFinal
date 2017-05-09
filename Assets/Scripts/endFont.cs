using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endFont : MonoBehaviour {

	Text screenText;
	int counter;
	public GameObject panel;
	public GameObject text;
	float timer;

	// Use this for initialization
	void Start () {
		screenText = GetComponent<Text> ();
		counter = 0;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (counter == 0) {
			screenText.color = new Color (0f, 0f, 0f, 132f);
			counter++;
		}
		else if (counter == 1) {
			counter++;
		}
		else if (counter == 2) {
			counter++;
		}
		else if (counter == 3) {
			screenText.color = new Color (255f, 255f, 255f, 132f);
			counter++;
		}
		else if (counter == 4) {
			counter++;
		}
		else if (counter == 5) {
			counter = 0;
		}
		if (timer > 2f) {
			panel.SetActive (true);
			text.SetActive (true);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene ("loginSnips");
		}
	}
}


// How can I make it alternate between having the text be red and white forever (flashing)