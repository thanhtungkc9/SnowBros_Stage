using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallBonus : MonoBehaviour {

    public float maxVelocity = 3.0f;
    public float force = 250.0f;
    public bool grounded = false;

    [SerializeField]
    GameObject Diamond;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (grounded)
        {
            if (GetComponent<Rigidbody2D>().velocity.x < maxVelocity)
            {
                if (transform.localScale.x > 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(maxVelocity, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-maxVelocity, 0);
                }
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            int numDiamonds = Random.Range(4, 6);
            for (int i=0;i<numDiamonds;i++)
            {
                GameObject diamond = Instantiate(Diamond, gameObject.transform.position, Quaternion.identity);
                diamond.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300.0f, 300.0f), Random.Range(300.0f, 800.0f)));
                //diamond.GetComponent<Rigidbody2D>().AddForce(new Vector2(300.0f,500.0f));
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
          grounded = false;
        }
    }
    public void CreateBonus()
    {

    }
}
