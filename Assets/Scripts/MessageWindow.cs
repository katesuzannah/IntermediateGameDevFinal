using System.Collections;
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
        "We",
        "It",
        "They",
    };

    string[] verbs =
    {
        "wanted",
        "did",
        "saw",
        "looked",
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
            Invoke("generateGenericReply", 1.5f);
        }
    }

    string generateMessage()
    {
        string newMessage = "";
        newMessage += pronouns[Random.Range(0, pronouns.Length)] + " ";
        if (Random.value > 0.5f) { newMessage += adverbs[Random.Range(0, adverbs.Length)] + " "; }
        newMessage += verbs[Random.Range(0, verbs.Length)] + " the ";
        newMessage += nouns[Random.Range(0, nouns.Length)] + " ";
        newMessage += conjunctions[Random.Range(0, conjunctions.Length)] + " ";
        newMessage += (pronouns[Random.Range(0, pronouns.Length)].ToLower()) + " ";
        if (Random.value > 0.5f) { newMessage += adverbs[Random.Range(0, adverbs.Length)] + " "; }
        newMessage += verbs[Random.Range(0, verbs.Length)] + " the ";
        newMessage += nouns[Random.Range(0, nouns.Length)];
        newMessage += punctuations[Random.Range(0, punctuations.Length)];
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
        GetComponent<TextData>().data = "You have no new messages!";
        newReply.GetComponent<TextData>().data = generateMessage();
    }
}
