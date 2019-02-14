using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSlide : MonoBehaviour
{
    private GameObject player, player2;
    private GameObject key;
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
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            key = GameObject.FindGameObjectWithTag("Key");
            if(key.GetComponent<Level1Key>().pickedUp == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Key Inserted");
                    MoveButton();
                }
            }
        }
        if(col.tag == "Player2")
        {
            key.GetComponent<Level1Key>().p2 = true;
            Debug.Log("Player2 has the key");
        }
    }
    void MoveButton()
    {
        Vector2 newPos = new Vector2(transform.position.x + 10, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newPos, Time.deltaTime * .5f);
    }
}
