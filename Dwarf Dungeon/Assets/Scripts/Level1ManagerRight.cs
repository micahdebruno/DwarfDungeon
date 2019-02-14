using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ManagerRight : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject keyPrefab;
    //public Transform keySpawnPoint;
    public int numEnemies;
    public Transform[] spawnPoints;
    private bool activated = false;
    public int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemiesLeft);
        if (activated && enemiesLeft == 0)
        {
            
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "Player" || col.tag == "Player2") && !activated)
        {
            activated = true;
            for (int i = 0; i < numEnemies; i++)
            {
                Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            }
            
        }
    }
}
