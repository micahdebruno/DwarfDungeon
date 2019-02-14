using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Door1 : MonoBehaviour
{
    private GameObject key;
    private GameObject player, player2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        key = GameObject.FindGameObjectWithTag("Key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player2")
        {
            if(key.GetComponent<Level1Key>().p2 == true && Input.GetMouseButtonDown(1))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
