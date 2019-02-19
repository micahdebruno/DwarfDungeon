using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed;
    public int health;
    public float weaponCD = 0.2f;
    public int playerDirection;
    [SerializeField]
    private GameObject weaponPrefab;
    public int numKeys;
    public Vector3 respawnPoint;
    public bool isSafe = false;
    [SerializeField]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            playerDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            playerDirection = 4;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            playerDirection = 3;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerDirection = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    void Attack()
    {
        anim.SetBool("isAttacking", true);
        speed = 0f;
        /*if (playerDirection == 1)
        {
            weaponPrefab.transform.rotation = new Quaternion(0, 0, 0, 0);
            Vector3 weaponPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Instantiate(weaponPrefab, weaponPos, weaponPrefab.transform.rotation);
        }
        if (playerDirection == 2)
        {
            weaponPrefab.transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 0));
            weaponPrefab.transform.Rotate(0, 0, -90);
            Vector3 weaponPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            Instantiate(weaponPrefab, weaponPos, weaponPrefab.transform.rotation);

        }
        if (playerDirection == 3)
        {
            weaponPrefab.transform.rotation = new Quaternion(0, 0, 180, 0);
            Vector3 weaponPos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            Instantiate(weaponPrefab, weaponPos, weaponPrefab.transform.rotation);
        }
        if (playerDirection == 4)
        {
            weaponPrefab.transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 0));
            weaponPrefab.transform.Rotate(0, 0, 90);
            Vector3 weaponPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            Instantiate(weaponPrefab, weaponPos, weaponPrefab.transform.rotation);
        }*/
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "RespawnPoint")
        {
            respawnPoint = this.transform.position;
        }
        if(col.tag == "Platform")
        {
            isSafe = true;
        }
        if (col.tag == "Hazard" && !isSafe)
          {
               Respawn();    
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Platform")
        {
            isSafe = false;
        }
    }
    void Respawn()
    {
        transform.position = respawnPoint;
    }
    public void AttackResetBool()
    {
        anim.SetBool("isAttacking", false);
        speed = 5f;
    }
}
