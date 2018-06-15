using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneBonus : MonoBehaviour {
    public float timeSkip = 30.0f;
    private int a, b;           //Format     Stage + a + "-" + b                ex: a=1 b=2 -> Stage1-2

    public Text sceneName;
    public void Start()
    {
        
    }
    public void Update()
    {
        if (timeSkip <= 0.0f)
            SceneController.LoadScene(3);
            
        else
            timeSkip -= Time.deltaTime;
    }
}
