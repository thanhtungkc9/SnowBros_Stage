using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scene1 : MonoBehaviour {
    public float timeSkip = 3.0f;
    private int a, b;           //Format     Stage + a + "-" + b                ex: a=1 b=2 -> Stage1-2

    public Text sceneName;
    public void Start()
    {
        
    }
    public void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss") == null)
        {
            if (GlobalControl.numGoldenKey==5)
            SceneController.LoadScene(4);
            else
                SceneController.LoadScene(3);

        }
    }
}
