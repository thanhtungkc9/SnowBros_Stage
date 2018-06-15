using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 4f;
    public int dmg = 1;
    public float forceX=100.0f;
    public float forceY=30.0f;
    public float timeExist = 0.4f;
    public Sprite bigBullet;

    private bool direction;
    private GameObject player;
    private Rigidbody2D bullet;
    private
    AudioSource audioPlayer;
    public  AudioClip audio_destroy;
    
    private float timeFly = 0;
    private void Awake()
    {
        player = GameObject.Find("Player");
        bullet = GetComponent<Rigidbody2D>();
        Bullet_LoadData();
        audioPlayer = GetComponent<AudioSource>();
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
 
      
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground"  || collision.gameObject.tag == "Wall"||collision.gameObject.tag=="Enemy"
            ||collision.gameObject.tag=="SnowBall"||collision.gameObject.tag=="Boss")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().mass = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetBool("isDestroy", true);
            audioPlayer.PlayOneShot(audio_destroy);
            if (collision.gameObject.tag=="Enemy"|| collision.gameObject.tag == "Boss")
            collision.gameObject.SendMessage("Damage", dmg);
            gameObject.layer = 14;
        }
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy"
              || collision.gameObject.tag == "SnowBall")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().mass = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetBool("isDestroy", true);
            if (collision.gameObject.tag == "Enemy")
                collision.gameObject.SendMessage("Damage", dmg);
            gameObject.layer = 14;
        }

    }
    private void Bullet_LoadData()
    {
       if (GlobalControl.isPowerUp==false)
        {
            dmg = 1;

        }
       else
        {
            dmg = 2;
            forceX = 150.0f;
        }
    }
}
