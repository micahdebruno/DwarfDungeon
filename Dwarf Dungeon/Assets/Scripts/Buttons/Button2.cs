﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Weapon2")
        {
            Debug.Log("Hammer hit button");
            this.GetComponent<SpriteRenderer>().enabled = false;
            anim.SetTrigger("Extend");
            anim.SetBool("Extended", true);
            Destroy(this.gameObject, 7f);
        }
    }
}
