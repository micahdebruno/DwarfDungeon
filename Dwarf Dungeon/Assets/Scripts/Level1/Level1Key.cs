using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Key : MonoBehaviour
{
    
    private GameObject player, player2;
    public bool pickedUp = false;
    public bool p1, p2 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            pickedUp = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            col.GetComponent<Player1>().numKeys++;
            
        }
    }
}
