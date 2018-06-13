using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloattingGround : MonoBehaviour {

    [SerializeField]
    Transform startPoint, endPoint;
    private float startX, endX;
    public float velocity = 1.5f;
    private int changeDirection = -1;
    private float constantY;

    private float timeChangeDirection = 0.0f;
    public float timeReset = 0;
	// Use this for initialization
	void Start () {
        constantY = transform.position.y;
        startX = startPoint.position.x;
        endX = endPoint.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        timeChangeDirection -= Time.deltaTime;
        // if (time)
        if ((transform.position.x > endX || transform.position.x < startX) && timeChangeDirection < 0)
        {
            
            velocity *= changeDirection;
            timeChangeDirection = 1.0f;
        }
        transform.position = new Vector2(velocity * Time.deltaTime + transform.position.x, transform.position.y);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);



    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.parent = null;
            //collision.rigidbody.gravityScale = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.parent = transform;
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);
        }
    }
    
}
