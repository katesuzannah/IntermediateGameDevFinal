using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    CharacterController playerCharCon;

	Vector3 moveVector;
	public float moveSpeed = 5f;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
        playerCharCon = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		//get mouse input data
		float mouseX = Input.GetAxis ("Mouse X");

		//rotate camera based on mouse movement
		transform.Rotate(0f, mouseX * 3f, 0f);

        //movement
        // moveVector = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed);
        // transform.Translate(moveVector * Time.deltaTime);
        float frontBack = Input.GetAxis("Vertical") * moveSpeed;
        float leftRight = Input.GetAxis("Horizontal") * moveSpeed;
        playerCharCon.Move(transform.forward * frontBack * Time.deltaTime);
        playerCharCon.Move(transform.right * leftRight * Time.deltaTime);

    }

    void FixedUpdate()
    {
        playerCharCon.Move(Vector3.up * Time.deltaTime * -5f);
    }

    void playerGravity()
    {
        
    }
}
