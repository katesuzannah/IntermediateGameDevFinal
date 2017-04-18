using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour {

    public GameObject pigeon;

    public GameObject secretPoliticalMessage;
    public GameObject secretPoliticoReply;

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
            CameraLook playCam = GameManager.Instance.player.GetComponent<CameraLook>();
            // playCam.currentlyHeld = playCam.emptyHold;

            //Take message away, give reply
            Invoke("generateGovernmentReply", 3f);
            Debug.Log("Replied!");
        }
    }

    void generateGovernmentReply()
    {
        Instantiate(secretPoliticoReply, new Vector3(3, 2, 4), Quaternion.identity);
    }
}
