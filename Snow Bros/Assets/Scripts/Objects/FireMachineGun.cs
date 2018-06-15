using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMachineGun : MonoBehaviour {

    public float timeFire = 0f;
    public bool rightToLeft = false;
    public bool isPlayerInRange=false;

    private float timeFireTemp;
    [SerializeField]
    GameObject fire;
    [SerializeField]
    Transform positionFire;
	// Use this for initialization
	void Start () {
        timeFireTemp = timeFire;

    }
	
	// Update is called once per frame
	void Update () {
        if (timeFire < 0 && isPlayerInRange)
        {
            GameObject tmp= Instantiate(fire, positionFire.position, Quaternion.identity);
            tmp.transform.localScale = gameObject.transform.localScale;
            tmp.transform.rotation = gameObject.transform.rotation;
            timeFire = timeFireTemp;
        }
        else
            timeFire -= Time.deltaTime;   }
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
            timeFire = 0;
        }
    }
}
