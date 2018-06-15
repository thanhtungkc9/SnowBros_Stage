using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_CheckKey : MonoBehaviour {
    public  GameObject player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    
}

// Update is called once per frame
    void Update() {
        if (player.transform.position.x >transform.position.x)
        {
            gameObject.transform.parent.GetComponent<Animator>().SetBool("isOpen", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GlobalControl.numBlueKey == 1 
            &&
            gameObject.transform.parent.GetComponent<Animator>().GetBool("isOpen")==false)
        {
            Transform door = gameObject.transform.parent;
            door.GetComponent<Animator>().SetBool("isOpen", true);
            GlobalControl.numBlueKey -= 1;
        }
    }

}
