﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour {

    public GameObject pigeon;

    public GameObject secretPoliticalMessage;
    public GameObject secretPoliticoReply;

    public GameObject replyMessage;

    string[] pronouns =
    {
        "I",
        "You",
        "He",
        "She",
    };

    string[] verbs =
    {
        "wanted",
        "did",
        "saw",
    };

    string[] adjectives =
    {

    };

    string[] nouns =
    {

    };

    string[] adverbs =
    {

    };
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Keep the letter in the room.
        if (secretPoliticalMessage != null && 
            (Mathf.Abs(secretPoliticalMessage.transform.position.x) > 5f
            || Mathf.Abs(secretPoliticalMessage.transform.position.z) > 5f))
        {
            secretPoliticalMessage.transform.position = Vector3.up;
            secretPoliticalMessage.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        // If political message is brought here, take away and respond with new political message.
        if(coll.gameObject == secretPoliticalMessage)
        {
            secretPoliticalMessage.transform.parent = transform;
            secretPoliticalMessage.GetComponent<Rigidbody>().isKinematic = true;
            secretPoliticalMessage.GetComponent<Rigidbody>().useGravity = false;
            secretPoliticalMessage = null;
            CameraLook playCam = GameManager.Instance.player.transform.Find("Main Camera").GetComponent<CameraLook>();
            // playCam.currentlyHeld = playCam.emptyHold;

            //Take message away, give reply
            Invoke("generateGovernmentReply", 1.5f);
            GetComponent<TextData>().data = "You have no new messages!";
            Debug.Log("Replied!");
        }
        else if(coll.transform.GetComponent<TextData>() != null
            && coll.transform.GetComponent<TextData>().messType == TextData.messageType.message)
        {
            CameraLook playCam = GameManager.Instance.player.transform.Find("Main Camera").GetComponent<CameraLook>();

            // GameObject heldMessage = coll.gameObject;
            coll.transform.parent = transform;
            coll.GetComponent<Rigidbody>().isKinematic = true;
            coll.GetComponent<Rigidbody>().useGravity = false;
            playCam.currentlyHeld = playCam.emptyHold;
            Destroy(coll.gameObject);
            generateGenericReply();
        }
    }

    string generateMessage()
    {
        string newMessage = "";
        newMessage += pronouns[Random.Range(0, pronouns.Length)] + " ";
        newMessage += verbs[Random.Range(0, pronouns.Length)] + " the";
        newMessage += nouns[Random.Range(0, pronouns.Length)] + " ";
        return newMessage;
    }

    void generateGovernmentReply()
    {
        GetComponent<TextData>().data = "You have 1 new message!";
        Instantiate(secretPoliticoReply, transform.position, Quaternion.identity);
    }

    void generateGenericReply()
    {
        GetComponent<TextData>().data = "You have 1 new message!";
        GameObject newReply = Instantiate(replyMessage);
        newReply.transform.position = transform.position - transform.forward.normalized;
        // Invoke("generateGovernmentReply", 1.5f);
        GetComponent<TextData>().data = "You have no new messages!";
        newReply.GetComponent<TextData>().data = generateMessage();
    }
}
