using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject theEnemy;
    public GameObject Player;
    public Vector3 spawnPoint;
    
    public float xPos, yPos;
    public int enemyCount;
    public bool accept;
    
    // Update is called once per frame
    void Update()
    {
        SpawnPoint();
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            Instantiate(theEnemy, spawnPoint, Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(0.1f);
            
        }
        

        
    }
    void SpawnPoint()
    {
        xPos = Random.Range(-10, 10);
        yPos = Random.Range(-10, 10);
        spawnPoint = Player.transform.position + new Vector3(xPos, 0, yPos);
        accept = SpawnPointOutside(spawnPoint);
        if (accept)
        {
            StartCoroutine(EnemyDrop());
        }
    }
    bool SpawnPointOutside(Vector3 spawnpPoint)
    {
        float x = spawnPoint.x;
        float y = spawnPoint.z;
        if(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) <= 25f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
