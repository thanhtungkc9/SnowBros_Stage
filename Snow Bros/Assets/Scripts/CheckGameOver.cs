using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CheckGameOver : MonoBehaviour {
    public float timeSkip = 3.0f;
    private int a, b;           //Format     Stage + a + "-" + b                ex: a=1 b=2 -> Stage1-2
    public Image gameOver;

    public void Start()
    {
        Time.timeScale = 0;
    }
    public void Update()
    {
        if (GlobalControl.Lives <0)
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
            ;
    }
}
