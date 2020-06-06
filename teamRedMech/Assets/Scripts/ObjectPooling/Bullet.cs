using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    public float speed = 20f;

    public float timeToDestroy;
    private float destroyTime;

    public float damage;

    public GameObject bullet;
    public Rigidbody rb;

    public void Start()
    {
        destroyTime = timeToDestroy;


    }

    public void OnObjectSpawn()
    {
        rb.velocity = transform.forward * speed;
    }

    public void Update()
    {
        DestroyTimer();
    }

    void DestroyTimer()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
        {
            bullet.SetActive(false);
            destroyTime = timeToDestroy;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
         if (other.tag == ("Enemy"))
        {
            //Add Damage Here
        }
    }
}
