using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public float stopDistance;
    public float attackSpeed;
    public float speed;
    public float timeBetweenAttacks;
    public int health;
    public GameObject itemPrefab;
    private float attackTime;
    [SerializeField]
    private GameObject player1, player2;
    private float damageTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        damageTime -= Time.deltaTime;
        if (damageTime < 0)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (player1 != null)
        {
            if (Vector2.Distance(transform.position, player1.transform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }
    IEnumerator Attack()
    {

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player1.transform.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Weapon" || col.tag == "Weapon2")
        {
            health--;
            damageTime = .1f;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            if (health <= 0)
            {
                Instantiate(itemPrefab, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
