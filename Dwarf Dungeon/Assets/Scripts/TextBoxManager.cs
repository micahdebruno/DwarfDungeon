using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    private GameObject player1, player2;
    public Canvas canvas1, canvas2;
    public Text text;
    public string[] textLines = { "You Picked Up A Key", "You Now Have A Key", "This Door Is Blocked From The Other Side","You Need A Key To Open This Door","Right Click To Unlock The Door" };
    private float displayTime = 0;
    private bool displayed = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas1.enabled = false;
        canvas2.enabled = false;
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if(displayTime <= 0)
        {
            canvas1.enabled = false;
        }
        if (player1.GetComponent<Player1>().numKeys > 0 && displayed == false)
        {
            displayed = true;
            displayTime = 2f;
            canvas1.enabled = true;
            text.text = textLines[0];
        }
        
        displayTime -= Time.deltaTime;
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            canvas1.enabled = true;
            displayTime = 2f;
            text.text = textLines[2];
        }
        if(col.tag == "Player2" && col.GetComponent<Player2>().numKeys < 1)
        {
            canvas2.enabled = true;
            displayTime = 2f;
            text.text = textLines[3];
        }
        if (col.tag == "Player2" && col.GetComponent<Player2>().numKeys >= 1)
        {
            canvas2.enabled = true;
            displayTime = 2f;
            text.text = textLines[4];
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            canvas1.enabled = false;
            
        }
        if (col.tag == "Player2")
        {
            canvas2.enabled = false;
            
        }
    }
}
