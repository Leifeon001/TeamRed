using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    ObjectPooler objectPooler;

    public Transform spawnPoint;
    public Transform otherSpawnPoint;

    public float rate;
    private float shootTimer;

    public float laserTimerMax;
    private float laserTimer;

    private bool startLaserTimer;
    private bool isLaserActive;

    public GameObject laser;


    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;

        isLaserActive = false;

        laserTimer = laserTimerMax;

        laser.SetActive(false);

        startLaserTimer = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootProjectile();
        FireLaser();
        StartLaserTimer();
    }

    public void ShootProjectile()
    {
           shootTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {

            if (shootTimer >= rate)
            {
                objectPooler.SpawnFromPool("Bullet", spawnPoint.position, spawnPoint.rotation);
                objectPooler.SpawnFromPool("Bullet", otherSpawnPoint.position, otherSpawnPoint.rotation);
                shootTimer = 0;
            }
        }
    }

    public void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !laser.active)
        {
            Debug.Log("Laser is Fireing");

            laser.SetActive(true);
            laserTimer = laserTimerMax;

            isLaserActive = true;

            startLaserTimer = true;


        }

    }

    public void StartLaserTimer()
    {

        if (startLaserTimer)
        {
            laserTimer -= Time.deltaTime;

            if (laserTimer <= 0)
            {
                TurnLaserOff();
            }
        }
    }

    public void TurnLaserOff()
    {
        laser.SetActive(false);
        laserTimer = laserTimerMax;
        startLaserTimer = false;
    }
}
