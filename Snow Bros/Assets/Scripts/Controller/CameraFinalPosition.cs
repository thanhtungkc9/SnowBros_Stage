using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFinalPosition : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            /*CameraControllerScript.SetFollowing(false);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position = 
                new Vector3(transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform.position.z);
            */
            // CameraControllerScript.UpdateBounds(GetComponent<BoxCollider2D>());
           GameObject tmp= GameObject.FindGameObjectWithTag("CameraBound");
            tmp.GetComponent<BoxCollider2D>().size = GetComponent<BoxCollider2D>().size;
            tmp.GetComponent<Transform>().position = transform.position;
            tmp.GetComponent<BoxCollider2D>().offset = GetComponent<BoxCollider2D>().offset;
        }
    }
}
