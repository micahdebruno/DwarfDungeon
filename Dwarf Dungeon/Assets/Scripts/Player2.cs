using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed;
    public int health;
    public int playerDirection;

    [SerializeField]
    private GameObject weaponPrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            playerDirection = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            playerDirection = 4;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            playerDirection = 3;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerDirection = 2;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        if (playerDirection == 1)
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
        }
    }
}
