using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookcase : MonoBehaviour {

    public bool bookPulled;
    Vector3 originalPos;
    Vector3 revealDest;
	// Use this for initialization
	void Start () {
        bookPulled = false;
        originalPos = transform.position;
        revealDest = transform.position + Vector3.up * 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (bookPulled)
        {
            revealIlluminati();
        }
	}

    void revealIlluminati()
    {
        float dist = Vector3.Distance(transform.position, revealDest);
        if(dist < 0.01f) { bookPulled = false; }
        transform.position = Vector3.Lerp(transform.position, revealDest, Time.deltaTime);
    }
}
