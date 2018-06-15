using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Elevator : MonoBehaviour {

    public bool isOn = false;
    public AudioClip audio_switch; 
        private AudioSource audioPlayer;
	// Use this for initialization
	void Start () {
        audioPlayer = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&isOn==false)
        {
            isOn = true;
            GetComponent<Animator>().SetBool("IsOn", true);
            audioPlayer.PlayOneShot(audio_switch);

        }
    }
}
