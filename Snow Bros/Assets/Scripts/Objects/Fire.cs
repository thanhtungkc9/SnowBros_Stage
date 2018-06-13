using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Fire collision with " + collision.gameObject.tag);
            gameObject.layer = 14;
            collision.gameObject.SendMessage("Damage", 1);
        }
    }
}
