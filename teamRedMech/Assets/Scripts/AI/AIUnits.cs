using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIUnits : MonoBehaviour
{
    #region Stats
    [Header("Stats")]
    public float health;
    public float LookRadius;
    public float Atkzone;
    public float wander;
    public Transform FirePos;
    public float rate;
    [HideInInspector] public float shootTimer;
    #endregion
    [HideInInspector] public bool Ally = false;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public ObjectPooler objectPooler;
    public List<GameObject> ItemDrop;
    [HideInInspector] public List<GameObject> Enemies;
    Vector3 randPoint = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = Atkzone;
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        shootTimer += Time.deltaTime;
    }
    public void EMove()
    {
        randPoint.x = Random.Range(-wander, wander);
        randPoint.y = Random.Range(-wander, wander);
        randPoint.z = Random.Range(-wander, wander);
        NavMeshHit hit;
        if(NavMesh.SamplePosition(transform.position, out hit, wander, NavMesh.AllAreas))
        {
            agent.SetDestination(randPoint);
        }
        //Vector3 temp = Vector3.forward * Speed;
        //transform.position += temp;
        ////transform.position = new vector3(random.insideunitsphere.x * lookradius , transform.position.y, random.insideunitsphere.z * lookradius);
    }
    public void FaceTarget(Transform Hunt)
    {
        Vector3 direction = (Hunt.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 7);
        agent.isStopped = true;
    }
    public virtual void Attack()
    {       
        shootTimer = 0;
    }
    public virtual void CurrHealth(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("Unit " + gameObject + " has been killed");
            if (ItemDrop.Count != 0)
            {
                Vector3 SpawnPoint = new Vector3(transform.position.x, 1.0f, transform.position.z);
                Instantiate(ItemDrop[Random.Range(0, ItemDrop.Count)], SpawnPoint, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }
}
