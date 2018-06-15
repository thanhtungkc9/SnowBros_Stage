using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Elevator : MonoBehaviour {

    public bool isOn = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOn = true;
            GetComponent<Animator>().SetBool("IsOn", true);
        }
    }
}
