using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    public float stopDistance;
    public float attackSpeed;
    public float speed;
    public float timeBetweenAttacks;
    private float attackTime;
    [SerializeField]
    private GameObject player;
    public bool player1;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
        Vector2 targetPosition = player.transform.position;

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
        if(col.tag == "Weapon")
        {
            Destroy(this.gameObject);
        }
    }
}
