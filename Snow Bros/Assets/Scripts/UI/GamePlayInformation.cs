using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GamePlayInformation : MonoBehaviour {

  

    [SerializeField]
    public Text numScores,numBlueKey,numGoldenKey,numMaxGoldenKey;
	// Use this for initialization
	void Start () {
     ;
	}
	
	// Update is called once per frame
	void Update () {
        numBlueKey.text = "x "+GlobalControl.numBlueKey.ToString();
        numGoldenKey.text = GlobalControl.numGoldenKey.ToString();
        numMaxGoldenKey.text ="/ "+ GlobalControl.maxGoldenKey.ToString();
        numScores.text = GlobalControl.Score.ToString();
    }
}
