using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrop : MonoBehaviour {

    [SerializeField]
    GameObject destroyedEffect;
    public float delayTime ;
    private void Awake()
    {
        delayTime = Random.Range(0.0f, 1.0f);
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (delayTime < 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.8f;
        }
        else
            delayTime -= Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {         
           if (collision.gameObject.tag=="Player")
                collision.gameObject.SendMessage("Damage", 1);
            GameObject tmp =Instantiate(destroyedEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(tmp,0.7f);
            Destroy(gameObject);
        }
    }
}
