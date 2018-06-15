using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallScript : MonoBehaviour {

    public float maxVelocity = 3.0f;
    public float force = 250.0f;
    public bool grounded = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(1, 1, 1);
        if (grounded)
        {
            if (GetComponent<Rigidbody2D>().velocity.x < maxVelocity)
            {
                if (transform.localScale.x > 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(maxVelocity, 0);
                   // GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
                }
                else
                {
                   // GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0));
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-maxVelocity, 0);
                }
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
        else if (collision.gameObject.tag=="Wall")
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Damage", 1);
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
          grounded = false;
        }
    }
}
