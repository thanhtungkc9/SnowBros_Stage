using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float maxSpeed = 4.0f;
    [SerializeField]
    GameObject destroyedEffect;
    private void Awake()
    {
      
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < maxSpeed)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100.0f, 0));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player")
        {         
           if (collision.gameObject.tag=="Player")
                collision.gameObject.SendMessage("Damage", 1);

            GameObject tmp =Instantiate(destroyedEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(tmp,0.7f);
            Destroy(gameObject);
        }
    }
}
