using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : AIUnits
{
    public override void Update()
    {
        base.Update();
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, LookRadius);
        //Debug.Log("Hello, I am Enemy AI");
        for (int i = 0; i < hitColliders.Length; i++)
        {
            //Debug.Log(hitColliders[i].name);
            CharacterMovement Character = hitColliders[i].GetComponent<CharacterMovement>();
            if (Character != null && !Enemies.Contains(hitColliders[i].gameObject))
            {
                Enemies.Add(hitColliders[i].gameObject);
                if (Enemies != null)
                {
                    //Debug.Log("Enemy found!");
                    agent.SetDestination(Enemies[0].transform.position);
                }
            }
            else if (Enemies.Contains(hitColliders[i].gameObject))
            {
                if (Enemies[0] != null)
                {
                    float distance = Vector3.Distance(Enemies[0].transform.position, transform.position);
                    Transform Chase = Enemies[0].transform;
                    if (distance <= agent.stoppingDistance)
                    {
                        //Attack Target 
                        FaceTarget(Chase);
                        if (shootTimer >= rate)
                        {
                            Attack();
                        }
                    }
                }
            }
            else if (Enemies.Count == 0)
            {
                if (agent.remainingDistance == 0)
                {
                    EMove();
                }
            }
        }

        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i] != null)
            {
                float distance = Vector3.Distance(Enemies[0].transform.position, transform.position);
                if (distance <= Atkzone)
                {
                    agent.SetDestination(Enemies[0].transform.position);
                }
                else
                {
                    Enemies.Clear();
                }
            }
            
        }
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Enemy Attack");
        objectPooler.SpawnFromPool("EnemyBullet", FirePos.position, FirePos.rotation);
    }
}
