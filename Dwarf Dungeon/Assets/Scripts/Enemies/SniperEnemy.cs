using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject projectilePrefab;
    public int health;
    public bool player1;
    private Level1Manager levelManager;
    private bool canShoot;
    public float shotReset = 3f;
    private float damageTime = 0;
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
        levelManager = GameObject.FindObjectOfType<Level1Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Shoot();
            damageTime -= Time.deltaTime;
            if (damageTime < 0)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
    void Shoot()
    {
        if (canShoot)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            canShoot = false;

        }
        shotReset -= Time.deltaTime;
        if (shotReset <= 0)
        {
            shotReset = 2f;
            canShoot = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Weapon" || col.tag == "Weapon2")
        {
            health--;
            damageTime = .1f;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
