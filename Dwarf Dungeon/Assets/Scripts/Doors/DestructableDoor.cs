using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableDoor : MonoBehaviour
{
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
        Debug.Log("Being collided with");
        if(col.tag == "Weapon2")
        {
            Destroy(this.gameObject);
        }
    }
}
