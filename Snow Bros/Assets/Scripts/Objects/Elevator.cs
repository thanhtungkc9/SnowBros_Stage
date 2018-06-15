using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    [SerializeField]
    Transform startPoint, endPoint;
    private float startY, endY;
    public float velocity = -1.5f;
    private int changeDirection = -1;
    private float constantX;

    [SerializeField]
    GameObject switch_Elevator;

    private float timeChangeDirection = 0.0f;
    public float timeReset = 0;
	// Use this for initialization
	void Start () {
        constantX = transform.position.x;
        startY = startPoint.position.y;
        endY = endPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        timeChangeDirection -= Time.deltaTime;
        // if (time)
        if ((transform.position.y < endY || transform.position.y > startY) && timeChangeDirection < 0)
        {
            
            velocity *= changeDirection;
            timeChangeDirection = 1.0f;
        }
       if (switch_Elevator.GetComponent<Animator>().GetBool("IsOn")&&switch_Elevator!=null)
            transform.position = new Vector2( transform.position.x, velocity * Time.deltaTime + transform.position.y);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.parent = null;
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
