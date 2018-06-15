using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : MonoBehaviour {

    [SerializeField]
    GameObject effectCollected;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("CollectItem", "BlueKey");
            Vector2 position = gameObject.transform.position;
            Destroy(gameObject);
            GameObject tmp = Instantiate(effectCollected, position, Quaternion.identity);
            Destroy(tmp, 0.5f);
        }
    }
}
