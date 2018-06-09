﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour {


    public const int STATE_IDLE = 0;
    public const int STATE_WALK = 1;
    public const int STATE_JUMP = 2;
    public const int STATE_THROW = 3;
    public const int STATE_PUSH = 4;
    public const int STATE_KICK = 5;
    public const int STATE_RUNPUSH = 6;
    public const int STATE_RUN = 7;
    public const int STATE_FLY = 8;
    public const int STATE_DIE = 9;
    public const int STATE_RESPAWN = 10;
    public const int STATE_RUNTHROW = 11;

    public Rigidbody2D playerBody;
    private Animator playerAnimator;
    public Transform shootPoint;
    [SerializeField]
    private GameObject bullet;

    //Sound
    [SerializeField]
    public AudioClip audio_throw,audio_respawn,audio_jump;
    public AudioSource audioPlayer;


    public float jumpForce ;
    public float moveForce ;
    public float maxVelocity ;
    public bool grounded = false;

    public float timeImmortal = 5.0f;

    public bool isMoveLeft, isMoveRight, isShoot, isJump;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
       
    }

    // Use this for initialization
    void Start() {
        Player_LoadData();
        GlobalControl.CurrentScene = SceneManager.GetActiveScene().buildIndex;
        audioPlayer = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate() {
        //Keyboard_Move();
        GlobalControl.Score++;
        Keyboard_Move();

        if (Input.GetKey(KeyCode.Space)) SceneManager.LoadScene("TransitionScene");
       
    }

    void OnCollisionEnter2D(Collision2D target)
    {      
        if ((target.gameObject.tag == "Ground" || target.gameObject.tag == "Freeze4") && playerBody.velocity.y < 0.1f)
        {
            grounded = true;
            float h = Input.GetAxisRaw("Horizontal");
             if (h != 0&&isMoveLeft==false&&isMoveRight==false)
            {
                playerAnimator.SetInteger("CurrentState", STATE_WALK);
            }
            else 
            {

                playerAnimator.SetInteger("CurrentState", STATE_IDLE);

            }
        }
    }

    void OnCollisionExit2D(Collision2D target)
    {
        if ((target.gameObject.tag=="Ground" || target.gameObject.tag == "Freeze4") && playerBody.velocity.y < -0.2f)
        {
            grounded = false;
        }        
    }
    void OnCollisionStay2D(Collision2D target)
    {
    
        if (target.gameObject.tag == "Freeze4" &&playerAnimator.GetInteger("CurrentState")==STATE_WALK)
        {
            playerAnimator.SetInteger("CurrentState", STATE_PUSH);
        }
    }

    void Keyboard_Move()
    {
        int currentState = playerAnimator.GetInteger("CurrentState");
        if (currentState == STATE_DIE || currentState == STATE_RESPAWN || currentState == STATE_FLY)
            return;
        float h = Input.GetAxisRaw("Horizontal");
        float forceX = 0f;
        float forceY = 0f;

        if (h > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            if (playerBody.velocity.x < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 0.5f;
                }
            }
            playerBody.AddForce(new Vector2(forceX, forceY));
        }
        else if (h < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            if (playerBody.velocity.x > -maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 0.5f;
                }
            }
            playerBody.AddForce(new Vector2(forceX, forceY));
        }
        else if (h == 0)
        {
            //playerBody.velocity=new Vector2(0,playerBody.velocity.y);
        }
       

    }

    public void MoveLeft()
    {
        int currentState = playerAnimator.GetInteger("CurrentState");
        if (currentState == STATE_DIE || currentState == STATE_RESPAWN || currentState == STATE_FLY)
            return;
        float forceX = 0f;
        float forceY = 0f;
        Vector3 scale = transform.localScale;
        scale.x = -1f;
        transform.localScale = scale;
        if (playerBody.velocity.x > -maxVelocity)
        {
            if (grounded)
            {
                forceX = -moveForce;
            }
            else
            {
                forceX = -moveForce * 0.5f;
            }
        }
        playerBody.AddForce(new Vector2(forceX, forceY));
    }
    public void MoveRight()
    {
        int currentState = playerAnimator.GetInteger("CurrentState");
        if (currentState == STATE_DIE || currentState == STATE_RESPAWN || currentState == STATE_FLY)
            return;
        float forceX = 0f;
        float forceY = 0f;
        Vector3 scale = transform.localScale;
        scale.x = 1f;
        transform.localScale = scale;
        if (playerBody.velocity.x < maxVelocity)
        {
            if (grounded)
            {
                forceX = moveForce;
            }
            else
            {
                forceX = moveForce * 0.5f;
            }
        }
        playerBody.AddForce(new Vector2(forceX, forceY));
    }

    public void Throw()
    {
        
    }
 
    public void Jump()
    {
        if (grounded &&playerAnimator.GetInteger("CurrentState") != STATE_JUMP)
        {
            grounded = false;
            audioPlayer.PlayOneShot(audio_jump);
            playerAnimator.SetInteger("CurrentState", STATE_JUMP);
        }
    }
    public IEnumerator Attack()
    {
       
            audioPlayer.PlayOneShot(audio_throw);
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
        

        yield return new WaitForSeconds(.1f);
    }
    public void Player_LoadData()
    {
        moveForce = GlobalControl.moveForce;
        jumpForce = GlobalControl.jumpForce;
        maxVelocity = GlobalControl.maxVelocity;
    }
    public void Player_SaveData()
    {
        GlobalControl.moveForce=moveForce ;
        GlobalControl.jumpForce= jumpForce  ;
        GlobalControl.maxVelocity= maxVelocity  ;
    }
}
