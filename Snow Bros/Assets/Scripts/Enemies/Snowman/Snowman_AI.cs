using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman_AI : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    GameObject snowBall;

    private Transform playerTranform;

    [SerializeField]
    Transform positionThrow;

    [SerializeField]
    float rangeX, rangeY;

    private bool isInrange = false;

    //Information
    public int currentHealth = 3;

    private void Awake()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<=0)
        {
            Death();
        }
        if (((transform.position.x - playerTranform.position.x < rangeX) && transform.localScale.x > 0.0f && (transform.position.x - playerTranform.position.x >0))
            || ((playerTranform.position.x - transform.position.x < rangeX) && transform.localScale.x < 0.0f && (playerTranform.position.x - transform.position.x>0))
            ) isInrange = true;
        else isInrange = false;
        if (isInrange&&GetComponent<Animator>().GetBool("Throw")==false)
            GetComponent<Animator>().SetBool("Throw", true);
        if (!isInrange) GetComponent<Animator>().SetBool("Throw", false);




    }
    void ThrowSnowball()
    {
        GameObject snowball = Instantiate(snowBall, positionThrow.position, Quaternion.identity);
       if (transform.localScale.x>0.0f) snowball.transform.localScale =new Vector2(-0.5f,-0.5f);
        else snowball.transform.localScale = new Vector2(0.5f, 0.5f);


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
