using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject keyPrefab;
    public Transform keySpawnPoint;
    public int numEnemies;
    public Transform[] spawnPoints;
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && enemyPrefab == null)
        {
            Instantiate(keyPrefab, keySpawnPoint.position, keySpawnPoint.rotation);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "Player" || col.tag == "Player2") && !activated)
        {
            activated = true;
            for(int i = 0; i < numEnemies; i++)
            {
                Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            }
            //Destroy(this.gameObject, .1f);
        }
    }
}
