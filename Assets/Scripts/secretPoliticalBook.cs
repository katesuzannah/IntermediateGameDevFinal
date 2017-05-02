using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretPoliticalBook : MonoBehaviour {

    public GameObject bookcase;
    public GameObject govRoom;
    Vector3 originalPos;
    float maxDistance = 0.2f;
    bool pulled;

	// Use this for initialization
	void Start () {
        originalPos = transform.position;
        pulled = false;
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(transform.position, originalPos);
        if(dist > maxDistance && !pulled)
        {
            bookcase.GetComponent<bookcase>().bookPulled = true;
            pulled = true;
            govRoom.SetActive(true);
        }
	}

    void OnCollisionEnter(Collision coll)
    {

    }
}
