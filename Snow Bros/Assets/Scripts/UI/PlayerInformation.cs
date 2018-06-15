using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerInformation : MonoBehaviour {

    public Sprite[] Hearts;
    [SerializeField]
    PlayerScript player;
    [SerializeField]
    Image Heart;

    [SerializeField]
    public Text numLives;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        Heart.sprite = Hearts[player.currentHealth];
        numLives.text = "x " + GlobalControl.Lives;

    }
}
