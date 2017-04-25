using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminatiGameOver : MonoBehaviour {
	
	Vector3 startposition;
	public float speed;
	public float shakeSpeed;

	// Use this for initialization
	void Start () {
		startposition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (startposition.x + Mathf.Sin(Time.time * speed) * shakeSpeed, transform.position.y + Mathf.Sin(Time.time * speed) * shakeSpeed, transform.position.z);
	}
}
