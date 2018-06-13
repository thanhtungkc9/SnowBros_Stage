using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball_Snowman : MonoBehaviour {

    public int dmg = 10;
    public float forceX = 120.0f;
    public float forceY = 15.0f;

	// Use this for initialization
	void Start () {

        if (transform.localScale.x > 0.0f)
        {
            Vector3 scale = transform.localScale;
            scale.x = 0.5f;
            transform.localScale = scale;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
        }
        else if (transform.localScale.x < 0.0f)
        {
            Vector3 scale = transform.localScale;
            scale.x = -0.5f;
            transform.localScale = scale;
            ;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-forceX, forceY));
            //  bullet.velocity = new Vector2(-1f, 0f);

        }
    }
	
	// Update is called once per frame
	void Update () {

        
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player"||collision.gameObject.tag=="Ground")
        {
            Debug.Log("BulletFire collision with " + collision.gameObject.tag);
            if (collision.gameObject.tag == "Player")
                collision.gameObject.SendMessage("Damage", 1);
            Destroy(gameObject);

        }
    }
}
