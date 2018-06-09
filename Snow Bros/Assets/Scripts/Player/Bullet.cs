using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 8f;
    public int dmg = 10;
    public float forceX=120.0f;
    public float forceY=15.0f;
    public float timeExist = 0.4f;
    public Sprite bigBullet;

    private bool direction;
    private GameObject player;
    private Rigidbody2D bullet;

    
    private float timeFly = 0;
    private void Awake()
    {
        player = GameObject.Find("Player");
        bullet = GetComponent<Rigidbody2D>();
        Bullet_LoadData();
    }

    // Use this for initialization
    void Start () {

        if (player.transform.localScale.x == 1f)
        {
            direction = true;
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            bullet.AddForce(new Vector2(forceX, forceY));
        }
        else if (player.transform.localScale.x == -1f)
        {
            direction = false;
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            ;
            bullet.AddForce(new Vector2(-forceX, forceY));
          //  bullet.velocity = new Vector2(-1f, 0f);

        }
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Fly());
      
    }

    IEnumerator Fly()
    {
        if (direction)
        {

            
        }
        else
        {

            
        }
        yield return new WaitForSeconds(.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Item" || collision.gameObject.tag == "Wall")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().mass = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            GetComponent<Animator>().SetBool("isDestroy", true);
        }
            
    }

    private void Bullet_LoadData()
    {
        dmg = GlobalControl.damage;
        timeExist = GlobalControl.timeExist;
        GetComponent<Rigidbody2D>().mass = GlobalControl.mass;
        if (GlobalControl.spriteName=="BigBullet") GetComponent<SpriteRenderer>().sprite=bigBullet;
    }
}
