using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject worldCanvas;
    public GameObject screenCanvas;
    public GameObject infoBox;
    public GameObject player;
    public Transform illuminatiMan;

    public AudioClip[] compBeeps;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
