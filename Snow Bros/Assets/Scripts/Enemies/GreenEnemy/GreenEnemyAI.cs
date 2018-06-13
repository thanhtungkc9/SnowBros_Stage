using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemyAI : MonoBehaviour
{

    private CircleCollider2D GreenEnemyColider;
    private Animator GreenEnemyAnimator;
    public Rigidbody2D GreenEnemyBody;
    private Transform playerTranform;
    public PhysicsMaterial2D bounce;

    public float startX, endX;
    public float walkingDistance = 10.0f;
    public bool isJumpPosition = false;

    public bool grounded = false;
    public bool walled = false;
    private bool playerkicked = false; //nếu bị player đá thì sẽ k còn tan băng
    public float jumpForce = 1400f;

    public int STATE_FALL = -2;
    public int STATE_IDLE = 0;
    public int STATE_WALK = 1;
    public int STATE_TURN = 2;
    public int STATE_ATTACK1 = 3;
    public int STATE_ATTACK2 = 4;
    public int STATE_DIE1 = 5;
    public int STATE_DIE2 = 6;

   

    public float moveXVelocity = 100f;
    public float moveForce = 150f;
    public float maxVelocity = 1.5f;
    public float time = 0.0f;

    //Chi so enemy
    public int currentHealth = 3;


    [SerializeField]
    private GameObject bulletFire;
    [SerializeField]
    private Transform shootPointHorizontal,shootPointVertical;
    [SerializeField]
    private Transform startPoint, endPoint;

    //trang thai enemy
    public bool isShoot = false;

    private void Awake()
    {
        GreenEnemyColider = GetComponent<CircleCollider2D>();
        GreenEnemyBody = GetComponent<Rigidbody2D>();
        GreenEnemyAnimator = GetComponent<Animator>();
        playerTranform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Use this for initialization
    void Start()
    {
        startX = startPoint.position.x;
        endX = endPoint.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth<=0)
        {
            Death();
        }
        time += Time.deltaTime;       
       if ((transform.position.x<startX&&transform.localScale.x<0.0f)||(transform.position.x>endX&& transform.localScale.x > 0.0f))
        {
            GreenEnemyAnimator.SetInteger("GreenEnemyCurrentState", STATE_TURN);
            GreenEnemyBody.velocity = new Vector2(0, 0);
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

    void Damage(int dmg)
    {
        if (gameObject.layer != 14)
            currentHealth -= dmg;
        Debug.Log(currentHealth);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public IEnumerator Attack1()
    {
      //  if (transform.localScale.x > 0)
        {
            GameObject newObject =Instantiate(bulletFire, shootPointHorizontal.position, Quaternion.identity);
            if (transform.localScale.x < 0)
                newObject.transform.localScale = new Vector2(-1, newObject.transform.localScale.y);
        }

        yield return new WaitForSeconds(.5f);
    }

    public IEnumerator Attack2()
    {
        //  if (transform.localScale.x > 0)
        {
            GameObject newObject = Instantiate(bulletFire, shootPointVertical.position, Quaternion.identity);
            // if (transform.localScale.x < 0)
            newObject.transform.Rotate(0, 0, -90);
        }

        yield return new WaitForSeconds(.5f);
    }

}
