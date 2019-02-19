using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public bool player1;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject particleSystem;
    private Vector3 projectilePath;
    private Vector3 pos;
    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        if (player1)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (!player1)
        {
            player = GameObject.FindGameObjectWithTag("Player2");
        }
        projectilePath = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, projectilePath, _speed * Time.deltaTime);
        if (transform.position == projectilePath)
        {
            pos = transform.position;
            Instantiate(particleSystem, pos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "Player2" || col.tag == "Weapon" || col.tag == "Weapon2" || col.tag == "Wall")
        {
            pos = transform.position;
         
            Instantiate(particleSystem, pos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    }
