﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour {

    public GameObject pigeon;

	AudioSource youveGotMail;

    public GameObject secretPoliticalMessage;
    public GameObject secretPoliticoReply;
    public GameObject pillowMessage;
    public GameObject pillowReply;
    public GameObject wardrobeMessage;
    public GameObject wardrobeReply;
    public GameObject govMessage;
    public GameObject govReply;

    public GameObject replyMessage;

    string[] names =
    {
        "Kate",
        "Snippy",
        "Josh",
        "Grant",
        "Jake",
        "Finn",
        "Steven",
        "Robert",
        "Jenny",
        "Tom",
    };

    string[] pronouns =
    {
        "I",
        "You",
        "He",
        "She",
        "We",
        "It",
        "They",
    };

    string[] verbs =
    {
        "wanted",
        "did",
        "saw",
        "looked at",
        "stopped",
        "took pictures of"
    };

    string[] adjectives =
    {
        "silly",
        "huge",
        "small",
        "fat",
        "sparkly",
    };

    string[] nouns =
    {
        "cake",
        "dance",
        "booze",
        "man",
        "hair",
    };

    string[] adverbs =
    {
        "really",
        "quickly",
        "slowly",
        "hugely",
        "stupidly",
    };

    string[] conjunctions =
    {
        "and",
        "but",
    };

    char[] punctuations =
    {
        '.',
        '?',
        '!',
    };

	void Start () {
		youveGotMail = GetComponent<AudioSource> ();
	}

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
        if (coll.gameObject == secretPoliticalMessage)
        {
            
            CameraLook playCam = GameManager.Instance.player.transform.Find("Main Camera").GetComponent<CameraLook>();
            playCam.currentlyHeld = playCam.emptyHold;
            Destroy(coll.gameObject);
            //Take message away, give reply
            Invoke("generateGovernmentReply", 1.5f);
            GetComponent<TextData>().data = "You have no new messages!";
            Debug.Log("Replied!");
        }
        else if (coll.gameObject == wardrobeMessage)
        {
            CameraLook playCam = GameManager.Instance.player.transform.Find("Main Camera").GetComponent<CameraLook>();
            playCam.currentlyHeld = playCam.emptyHold;
            Destroy(coll.gameObject);
            Invoke("generateWardrobeReply", 1.5f);
        }
        else if (coll.gameObject == pillowMessage)
        {
            CameraLook playCam = GameManager.Instance.player.transform.Find("Main Camera").GetComponent<CameraLook>();
            playCam.currentlyHeld = playCam.emptyHold;
            Destroy(coll.gameObject);
            Invoke("generatePillowReply", 1.5f);
        }
        else if (coll.gameObject == govMessage)
        {

            CameraLook playCam = GameManager.Instance.player.transform.Find("Main Camera").GetComponent<CameraLook>();
            playCam.currentlyHeld = playCam.emptyHold;
            Destroy(coll.gameObject);
            Invoke("generateGovReply", 1.5f);
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
            Invoke("generateGenericReply", 1.5f);
        }
    }

    string generateMessage()
    {
        string newMessage = names[Random.Range(0, names.Length)] + " says: \n\"";
        newMessage += pronouns[Random.Range(0, pronouns.Length)] + " ";
        if (Random.value > 0.5f) { newMessage += adverbs[Random.Range(0, adverbs.Length)] + " "; }
        newMessage += verbs[Random.Range(0, verbs.Length)] + " the ";
        newMessage += nouns[Random.Range(0, nouns.Length)] + " ";
        newMessage += conjunctions[Random.Range(0, conjunctions.Length)] + " ";
        int nextPronounIdx = Random.Range(0, pronouns.Length);
        string nextPro = pronouns[nextPronounIdx];
        if(nextPro != pronouns[0]) {newMessage += nextPro.ToLower() + " "; }
        else { newMessage += nextPro + " "; }
        if (Random.value > 0.5f) { newMessage += adverbs[Random.Range(0, adverbs.Length)] + " "; }
        newMessage += verbs[Random.Range(0, verbs.Length)] + " the ";
        newMessage += nouns[Random.Range(0, nouns.Length)];
        newMessage += punctuations[Random.Range(0, punctuations.Length)] + "\"";
        return newMessage;
    }

    void generateGovernmentReply()
    {
		youveGotMail.Play ();	
        GetComponent<TextData>().data = "You have 1 new message!";
        Instantiate(secretPoliticoReply, transform.position, Quaternion.identity);
    }

    void generateWardrobeReply()
    {
		youveGotMail.Play ();
        GetComponent<TextData>().data = "You have 1 new message!";
        Instantiate(wardrobeReply, transform.position, Quaternion.identity);
    }

    void generatePillowReply()
    {
		youveGotMail.Play ();
        GetComponent<TextData>().data = "You have 1 new message!";
        Instantiate(pillowReply, transform.position, Quaternion.identity);
    }

    void generateGovReply()
    {
		youveGotMail.Play ();
        GetComponent<TextData>().data = "You have 1 new message!";
        Instantiate(govReply, transform.position, Quaternion.identity);
    }

    void generateGenericReply()
    {
		youveGotMail.Play ();
        GetComponent<TextData>().data = "You have 1 new message!";
        GameObject newReply = Instantiate(replyMessage);
        newReply.transform.position = transform.Find("pigeon").position + transform.Find("pigeon").forward * 0.6f;
        GetComponent<TextData>().data = "You have no new messages!";
        newReply.GetComponent<TextData>().data = generateMessage();
    }
}
