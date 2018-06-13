using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallDrop : MonoBehaviour {

    public float timeThrowSnowball = 4.0f;
    public bool rightToLeft = false;
    public bool isPlayerInRange=false;

    [SerializeField]
    GameObject snowBall;
    [SerializeField]
    Transform positionThrow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeThrowSnowball < 0 && isPlayerInRange)
        {
            GameObject snowball= Instantiate(snowBall, positionThrow.position, Quaternion.identity);
            timeThrowSnowball = 4.0f;
            snowball.transform.localScale = transform.localScale;
        }
        else
            timeThrowSnowball -= Time.deltaTime;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
}
