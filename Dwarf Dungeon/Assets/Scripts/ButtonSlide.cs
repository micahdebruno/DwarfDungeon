using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSlide : MonoBehaviour
{
    private GameObject player, player2;
    private GameObject key;
    private bool hasKey = false;
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
        if(col.tag == "Player" && col.GetComponent<Player1>().numKeys > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Key Inserted");
                col.GetComponent<Player1>().numKeys--;
                MoveButton();
            }
        }
        if(col.tag == "Player2")
        {
            col.GetComponent<Player2>().numKeys++;
            Debug.Log("Player2 has the key");
        }
    }
    void MoveButton()
    {
        Vector2 newPos = new Vector2(transform.position.x + 2, transform.position.y);
        transform.position = newPos;//Vector2.MoveTowards(transform.position, newPos, Time.deltaTime * .5f);
    }
}
