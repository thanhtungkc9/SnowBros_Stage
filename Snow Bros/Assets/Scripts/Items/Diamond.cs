using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    [SerializeField]
    GameObject effectCollected;

    public Sprite[] colorr;
    public int color = 0;
    // Use this for initialization
    void Start()
    {
        if (color == 0) color = Random.Range(1, 4);
        if (color == 2) GetComponent<SpriteRenderer>().sprite = colorr[0];
        else if (color == 3) GetComponent<SpriteRenderer>().sprite = colorr[1];
        else GetComponent<SpriteRenderer>().sprite = colorr[2];
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("CollectItem", "Diamond");
            Vector2 position = gameObject.transform.position;
            Destroy(gameObject);
            GameObject tmp = Instantiate(effectCollected, position, Quaternion.identity);
            Destroy(tmp, 0.5f);
        }
    }
}
