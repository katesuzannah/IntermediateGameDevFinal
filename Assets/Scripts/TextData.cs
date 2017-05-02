using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextData : MonoBehaviour {

    public string data;
    public messageType messType;

    public enum messageType
    {
        book = 0x01,
        message = 0x02,
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
