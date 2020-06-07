using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    private float xPos;
    private float yPos;
    public GameObject theEnemy;
    public GameObject Player;
    public Collider col;
    public int numberOfEnemies;
    public int enemyCount;
    void Update()
    {
       

        StartCoroutine(EnemyDrop());
        OnTriggerEnter(col);
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount< numberOfEnemies)
        {
            xPos = Random.Range(xMin, xMax);
            yPos = Random.Range(yMin, yMax);
            Instantiate(theEnemy, new Vector3(xPos, Player.transform.position.y, yPos), Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(0.1f);
            
        }
    }  
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            enemyCount--;
        }
    }
}
