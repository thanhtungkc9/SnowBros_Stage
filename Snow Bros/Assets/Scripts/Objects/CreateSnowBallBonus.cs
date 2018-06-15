using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSnowBallBonus : MonoBehaviour {


    [SerializeField]
    GameObject snowBallBonus;
    [SerializeField]
    Transform startPoint,endPoint;

    Transform playerTransform;
    public float timeCreateSnowballBonus;
    private float startX, endX;
    private float timeCreate;
	// Use this for initialization
	void Start () {
        startX = startPoint.position.x;
        endX = endPoint.position.x;
        timeCreate = timeCreateSnowballBonus;
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
       if (timeCreateSnowballBonus<0.0f)
        {         
            timeCreateSnowballBonus = timeCreate;
            Instantiate(snowBallBonus, gameObject.transform.position, Quaternion.identity);
            transform.position = new Vector2(Random.Range(startX, endX), transform.position.y);
           // transform.position = new Vector2(playerTransform.position.x+Random.Range(-1.0f,1.0f), transform.position.y);
        }
       else
        {
            timeCreateSnowballBonus -= Time.deltaTime;
        }
	}

}
