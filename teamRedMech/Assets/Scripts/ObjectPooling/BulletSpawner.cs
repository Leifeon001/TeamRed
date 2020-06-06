using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetButton("Fire1"))
        {
            objectPooler.SpawnFromPool("Bullet", transform.forward, Quaternion.identity);
        }

    }
}
