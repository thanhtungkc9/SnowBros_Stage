using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_CheckKey : MonoBehaviour {
    public  GameObject player;

    public AudioClip open,close;
    public AudioSource audioPlayer;
    bool isClosed = false;
    public bool closeWhenPlayerWalkThrough = true;
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        audioPlayer = GetComponent<AudioSource>();
}

// Update is called once per frame
    void Update() {
        if (player.transform.position.x > transform.position.x && isClosed == false
            && closeWhenPlayerWalkThrough
            && Mathf.Abs(player.transform.position.y - transform.position.y) < 3.0f
            )
        {
            gameObject.transform.parent.GetComponent<Animator>().SetBool("isOpen", false);
            audioPlayer.PlayOneShot(close);
            isClosed = true;
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
            audioPlayer.PlayOneShot(open);
            GlobalControl.numBlueKey -= 1;
        }
    }

}
