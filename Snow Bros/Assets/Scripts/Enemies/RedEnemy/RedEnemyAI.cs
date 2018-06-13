using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyAI : MonoBehaviour {

    private CircleCollider2D redEnemyColider;
    private Animator redEnemyAnimator;
    public  Rigidbody2D redEnemyBody;
    private Transform playerTranform;

    [SerializeField]
    Transform startPoint, endPoint;
    public float startX, endX;
    public bool isOutOfRange = false;

    public float walkingDistance = 10.0f;
    public bool isJumpPosition = false;

    public bool grounded = false;

    public int STATE_IDLE = 0;
    public int STATE_WALK = 1;
    public int STATE_TURN = 2;
    public int STATE_SCROLL = 3;
    public int STATE_DIE1 = 4;
    public int STATE_DIE2 = 5;


    public float moveXVelocity = 100f;
    public float moveForce = 150f;
    public float walkVelocity = 1.5f;
    public float scrollVelocity = 3.0f;
    public float time = 0.0f;

    private float timeChangeDirection = 3.0f;

    //Enemy Information
    public int currentHealth = 4;

    private void Awake()
    {
        redEnemyColider = GetComponent<CircleCollider2D>();
        redEnemyBody = GetComponent<Rigidbody2D>();
        redEnemyAnimator = GetComponent<Animator>();
        playerTranform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
    }

    // Use this for initialization
    void Start()
    {
        startX = startPoint.position.x;
        endX = endPoint.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
        timeChangeDirection -= Time.deltaTime;
        // if (time)
        
        if ((transform.position.x < startX && transform.localScale.x < 0.0f) || (transform.position.x > endX && transform.localScale.x > 0.0f))
        {
            isOutOfRange = true;
            redEnemyAnimator.SetInteger("RedEnemyCurrentState", STATE_TURN);
          
        }
        else
        {
            isOutOfRange = false;
        }
        if (playerTranform.position.x>startX&&playerTranform.position.x<endX
            || playerTranform.position.x < startX && playerTranform.position.x > endX
            )
        {
           if (playerTranform.position.x > redEnemyBody.position.x)
            {
                transform.localScale = new Vector2(1.0f, 1.0f);

            }
           else
                transform.localScale = new Vector2(-1.0f, 1.0f);
            redEnemyAnimator.SetInteger("RedEnemyCurrentState", STATE_SCROLL);
        }

       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Damage", 1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Damage", 1);
        }
    }


    public void Death()
    {
        Destroy(gameObject);
    }

    void Damage(int dmg)
    {
        if (gameObject.layer != 14)
            currentHealth -= dmg;
    }
}
