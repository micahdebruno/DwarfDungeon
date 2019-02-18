using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject enemyPrefab, bigEnemyPrefab;
    //public GameObject keyPrefab;
    //public Transform keySpawnPoint;
    
    public int numEnemies;
    public Transform[] spawnPoints;
    private bool activated = false;
    private bool disabled = false;
    public int enemiesLeft;
    //List<GameObject> listOfOpponents = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = numEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemiesLeft);
        if (activated && enemiesLeft == 0 && !disabled)
        {
            //Instantiate(keyPrefab, keySpawnPoint.position, keySpawnPoint.rotation);
            disabled = true;
            //Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "Player" || col.tag == "Player2") && !activated)
        {
            activated = true;
            for(int i = 0; i < numEnemies; i++)
            {
                if (i != numEnemies-1)
                {
                    Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
                }
                else
                {
                    Instantiate(bigEnemyPrefab, spawnPoints[0].position, spawnPoints[0].rotation);
                }
            }
            
            //listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            //Destroy(this.gameObject, .1f);
        }
    }
}
