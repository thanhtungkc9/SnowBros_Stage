using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffect : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
        gameObject.transform.parent.GetComponent<ParticleSystem>().Stop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            gameObject.transform.parent.GetComponent<ParticleSystem>().Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            gameObject.transform.parent.GetComponent<ParticleSystem>().Stop();
        }
    }
}
