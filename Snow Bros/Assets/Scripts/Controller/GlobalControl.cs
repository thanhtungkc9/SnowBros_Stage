using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    //GameController
    public static bool isPaused = false;

    //Player Information
    public static int Lives = 3;
    public static float maxVelocity = 3.0f;     //4.5f with Item
    public static float jumpForce = 1700.0f;
    public static float moveForce = 150.0f;
    public static Vector2 respawnPoint;

    public static int numBlueKey = 0;

    public static int preScore = 0;
    public static int Score = 0;

    public static int numGoldenKey = 0;
    public static int preGoldenKey = 0;
    public static int maxGoldenKey = 5;


    //PlayerBullet
    public static bool isPowerUp = false;

    //Scene Information
    public static int CurrentScene = 0;

    //Settings
    public static bool audio=true;
    public static bool sound=true;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void Player_SpeedItem()
    {
        maxVelocity = 4.5f;
    }
    public void Player_PowerItem()
    {
        isPowerUp = true;
    }

    public void Player_ResetItem()
    {
        moveForce = 150.0f;
        isPowerUp = false;
    }
    public void ResetItem()
    {
        numBlueKey = 0;
        numGoldenKey = preGoldenKey;
        Score = preScore;
    }
    public void Score_Add(int bonus)
    {
        Score += bonus;
    }

   


}
