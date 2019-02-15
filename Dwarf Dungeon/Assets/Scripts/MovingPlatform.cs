using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float ResetTime = 3f;
    
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = ResetTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpAndDown();
    }
    public void UpAndDown()
    {
        if (time > 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            time -= Time.deltaTime;
        }
        if (time < 0)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            time -= Time.deltaTime;
            if (time < -ResetTime) { time = ResetTime; }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" || col.tag == "Player2")
        {
            col.transform.parent = this.transform;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "Player2")
        {
            col.transform.parent = null;
        }
    }
}
