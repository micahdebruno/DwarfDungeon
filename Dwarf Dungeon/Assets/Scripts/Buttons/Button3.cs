using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{
    private MovingPlatform movingPlatform;
    // Start is called before the first frame update
    void Start()
    {
        movingPlatform = FindObjectOfType<MovingPlatform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player" || col.tag == "Player2")
        {
            movingPlatform.isActive = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "Player2")
        {
            movingPlatform.isActive = false;
        }
    }
}
