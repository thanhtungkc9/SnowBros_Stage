using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scene2 : MonoBehaviour {
    public float timeSkip = 3.0f;
    private int a, b;           //Format     Stage + a + "-" + b                ex: a=1 b=2 -> Stage1-2
    public Image missionCompleted;
    public Text sceneName;
    public void Start()
    {
        
    }
    public void Update()
    {
        if (GlobalControl.numGoldenKey == 4)
        {
            missionCompleted.gameObject.active = true;
            Time.timeScale = 0;
        }
            ;
    }
}
