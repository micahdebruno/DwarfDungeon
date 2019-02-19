using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWallBreak : MonoBehaviour
{
    public GameObject wallBreakParticle;
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
        if(col.tag != "Player" && col.tag != "Player2")
        {
            Instantiate(wallBreakParticle, transform.position, transform.rotation);
            Instantiate(wallBreakParticle, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(wallBreakParticle, new Vector3(transform.position.x + 1, transform.position.y +1, transform.position.z), transform.rotation);
            Instantiate(wallBreakParticle, new Vector3(transform.position.x + 1, transform.position.y -1, transform.position.z), transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
