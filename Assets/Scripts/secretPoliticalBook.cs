using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretPoliticalBook : MonoBehaviour {

    public GameObject bookcase;
    public GameObject govRoom;
    Vector3 originalPos;
    float maxDistance = 0.4f;
    bool pulled;
	AudioSource zelda;

	void Start () {
        originalPos = transform.position;
        pulled = false;
		zelda = GetComponent<AudioSource> ();
	}

	void Update () {
        float dist = Vector3.Distance(transform.position, originalPos);
        if(dist > maxDistance && !pulled)
        {
			zelda.Play ();
            bookcase.GetComponent<bookcase>().bookPulled = true;
            pulled = true;
            govRoom.SetActive(true);
        }
	}
}
