using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Boss1 : MonoBehaviour {
    private Animator boss1Animator;
    public Rigidbody2D boss1Body;
    public Transform fireBallPoint;
    public Transform[] fireDropPoint;
    public bool grounded = false;

    public int STATE_IDLE = 0;
    public int STATE_ATTACK = 1;
    public int STATE_JUMP = 2;
    public int STATE_DIE = 3;
    public int LAST_ACTION = 1;

    public float jumpForce=2100.0f;

    [SerializeField]
    public GameObject fireBall,fireDrop;
    //
    [SerializeField]
    private int Health=20;
    // Use this for initialization
    void Start () {

    }
    void Awake()
    {
        boss1Animator = GetComponent<Animator>();
        boss1Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Health <= 0)
        {
            Destroy(gameObject, 5.0f);
            boss1Animator.SetInteger("Boss1CurrentState", STATE_DIE);
        }
	}
    void OnCollisionEnter2D(Collision2D target)
    {
     
        if ((target.gameObject.tag == "Ground"|| target.gameObject.tag == "Wall") && boss1Body.velocity.y < 0.1f)
        {
            grounded = true;
            boss1Animator.SetInteger("Boss1CurrentState", STATE_IDLE);
        }
    }
    void OnCollisionExit2D(Collision2D target)
    {
        if ((target.gameObject.tag == "Ground"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            collision.gameObject.SendMessage("Damage", 1);
            collision.gameObject.SendMessage("KnockBack");
        }
    }
    public IEnumerator FireBallIE()
    {

        
        Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);


        yield return new WaitForSeconds(.1f);
    }

    public IEnumerator FireDropIE()
    {

        for (int i = 0; i < fireDropPoint.Length; i++)
        {
            float random = Random.Range(-2.0f, 1.0f);
            if (random > 0.0f)
                Instantiate(fireDrop, fireDropPoint[i].position, Quaternion.identity);
        }


        yield return new WaitForSeconds(.1f);
    }

        public void Attack1()
    {
        StartCoroutine(FireBallIE());
    }

    public void Attack2()
    {
        float random = Random.Range(-1.0f, 1.0f);
        if (random > 0.0f) 
        StartCoroutine(FireDropIE());
    }
}
