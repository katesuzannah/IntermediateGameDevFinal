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
	public GameObject creeperPaper;
	public GameObject laptopPopUpCanvas; 
	public GameObject creeperPaperCanvas;
    // public LayerMask ignorePlayer;
	public bool looking;

	void Start(){
		currentlyHeld = emptyHold;
		whereAt = emptyHold.GetComponent<Transform> ().position;
		looking = true;
	}

	// Update is called once per frame
	void Update () {
		float mouseY = Input.GetAxis ("Mouse Y");
		//clamp/constrain the X angle so we can't look too far up or down
		upDownLook -= mouseY;
		upDownLook = Mathf.Clamp (upDownLook, -26.6f, 26.6f); //constrain look 80 degrees

		if (looking) {
			//unroll the camera
			transform.eulerAngles = new Vector3 (upDownLook * 3f, transform.eulerAngles.y, 0f);
		}

		//initialize a Ray
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);

		//initialize rayHit
		RaycastHit rayHit = new RaycastHit();

        readObject(ray, rayHit);

        

		if (currentlyHeld.tag != "book") {
			//shoot raycast
			if (Physics.Raycast (ray, out rayHit, 5f)) {
                //pickup on click
                if (Input.GetMouseButtonDown (0)) {
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
						looking = false;

					} else if (currentlyHeld.tag == "paper"){
						creeperPaperCanvas.SetActive(true);
						Cursor.visible = true;
						Cursor.lockState = CursorLockMode.None;
						looking = false;
					}
				}
				if (Input.GetMouseButtonDown(0)) {
					currentlyHeld = rayHit.collider; //remember what we hit
					if (currentlyHeld.tag == "lightswitch") {
						//flicks lightswitch
						currentlyHeld.GetComponent<lamp>().switchOn ();
					}
                    if(currentlyHeld.tag == "closet")
                    {
                        // open closet door
                        currentlyHeld.GetComponent<openCloset>().openClosetDoor();
                    }
                    if(currentlyHeld.tag == "button")
                    {
                        if (!currentlyHeld.GetComponent<AudioSource>().isPlaying)
                        {
                            currentlyHeld.GetComponent<AudioSource>().clip = GameManager.Instance.compBeeps[Random.Range(0, 4)];
                            currentlyHeld.GetComponent<AudioSource>().Play();
                        }
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
			} else if (Input.GetKeyDown(KeyCode.E)){
				if ((currentlyHeld.tag == "book")
                    || (currentlyHeld.tag == "paper")) {
					currentlyHeld.transform.SetParent (null);
					currentlyHeld.GetComponent<Rigidbody> ().useGravity = true;
					currentlyHeld.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * 400f);
					currentlyHeld = emptyHold;
				}
			}
		}
	}
    void readObject(Ray ray, RaycastHit rayHit)
    {
        if (Input.GetMouseButton(1))
        {
            if(Physics.Raycast(ray, out rayHit, 5f))
            {
                if((rayHit.collider.tag == "book"
                   || rayHit.collider.tag == "message")
                   && rayHit.collider.transform.GetComponent<TextData>() != null)
                {
                    GameManager.Instance.infoBox.gameObject.SetActive(true);
                    string data = rayHit.collider.transform.GetComponent<TextData>().data;
                    GameManager.Instance.infoBox.transform.Find("Object Info").GetComponent<Text>().text = data;
                }
				if (rayHit.collider.tag == "laptop") {
					laptopPopUpCanvas.SetActive (true);
				}
            }
        }
        else
        {
            GameManager.Instance.infoBox.gameObject.SetActive(false);
			laptopPopUpCanvas.SetActive (false);
        }
    }
}
