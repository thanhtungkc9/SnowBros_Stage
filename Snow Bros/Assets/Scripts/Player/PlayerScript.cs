using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour {

    // State Number
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

    // object
    public Rigidbody2D playerBody;
    private Animator playerAnimator;
    public Transform shootPoint;
    [SerializeField]
    private GameObject bullet;

    //Sound
    [SerializeField]
    public AudioClip audio_throw,audio_respawn,audio_jump;
    public AudioSource audioPlayer;

    //Thông số giới hạn vận tốc, biến ktra chạm đất
    public float jumpForce ;
    public float moveForce ;
    public float maxVelocity ;
    public bool grounded = false;

    // Chỉ số nhân vật
    public int currentHealth;
    public int maxHealth;
    public float timeImmortal = 1.0f;

    public bool isMoveLeft, isMoveRight, isShoot, isJump;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
       
    }

    // Use this for initialization
    void Start() {
        //Player_LoadData();
        GlobalControl.CurrentScene = SceneManager.GetActiveScene().buildIndex;
        audioPlayer = GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (playerAnimator.GetInteger("CurrentState") >= STATE_DIE) return;
        //Keyboard_Move();
        GlobalControl.Score++;
        Keyboard_Move();
        timeImmortal -= Time.deltaTime;
        if (currentHealth<=0)
        {
            Death();
        }
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

       if (target.gameObject.tag=="Enemy")
        {
            StartCoroutine(Flasher());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snowball" || collision.gameObject.tag == "EnemyBullet")
            Debug.Log("Player collision with " + collision.gameObject.tag);
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

    public void Death()
    {
        playerAnimator.SetInteger("CurrentState", STATE_DIE);
    }

    public void Damage(int dmg)
    {

        if (timeImmortal <= 0)
        {
            currentHealth -= dmg;
            timeImmortal = 1.0f;
            if (currentHealth > 0 )GetComponent<Animation>().Play("FlashWhenDamaged");
        }
    }
    IEnumerator Flasher()
    {
        for (int i = 0; i < 5; i++)
        {
            //renderer.material.color = collideColor;
            //yield return new WaitForSeconds(.1f);
            //renderer.material.color = normalColor;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void KnockBack()
    {
        playerBody.AddForce(new Vector2(-650.0f * transform.localScale.x, 650.0f));
        Debug.Log("KnockBack");
    }

    public void CollectItem(string itemName)
    {
        switch (itemName)
        {
            case "Coin":
                break;
            case "Heart":
                break;
            case "SilverKey":
                break;
            case "GoldenKey":
                break;
        }
    }
}
