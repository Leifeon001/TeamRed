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

    public bool isUsingBullet1;
    public bool isUsingBullet2;
    public bool isUsingBullet3;

    public GameObject laser;

    public Pickup playerPickup;

    public int pickupAmmount;
    public int damageUpgradeCost;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;

        isLaserActive = false;

        laserTimer = laserTimerMax;

        laser.SetActive(false);

        startLaserTimer = false;

        isUsingBullet1 = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootProjectile();
        FireLaser();
        StartLaserTimer();
    }

    private void Update()
    {
        pickupAmmount = playerPickup.dropShipsSaved;
    }

    public void ShootProjectile()
    {
           shootTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {

            if (shootTimer >= rate)
            {

                if (isUsingBullet1)
                {
                    objectPooler.SpawnFromPool("Bullet", spawnPoint.position, spawnPoint.rotation);
                    objectPooler.SpawnFromPool("Bullet", otherSpawnPoint.position, otherSpawnPoint.rotation);
                    shootTimer = 0;
                }

                if (isUsingBullet2)
                {
                    objectPooler.SpawnFromPool("Bullet2", spawnPoint.position, spawnPoint.rotation);
                    objectPooler.SpawnFromPool("Bullet2", otherSpawnPoint.position, otherSpawnPoint.rotation);
                    shootTimer = 0;
                }

                if (isUsingBullet3)
                {
                    objectPooler.SpawnFromPool("Bullet3", spawnPoint.position, spawnPoint.rotation);
                    objectPooler.SpawnFromPool("Bullet3", otherSpawnPoint.position, otherSpawnPoint.rotation);
                    shootTimer = 0;
                }
            }
        }
    }

    public void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !laser.activeSelf && isUsingBullet3)
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

    public void ChangeBullet()
    {
        if (isUsingBullet1 && !isUsingBullet2 && !isUsingBullet3 && pickupAmmount >= damageUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(damageUpgradeCost);

            isUsingBullet1 = false;
            isUsingBullet2 = true;
            isUsingBullet3 = false;

            damageUpgradeCost++;
        }
        else if (!isUsingBullet1 && isUsingBullet2 && !isUsingBullet3 && pickupAmmount >= damageUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(damageUpgradeCost);

            isUsingBullet1 = false;
            isUsingBullet2 = false;
            isUsingBullet3 = true;

            damageUpgradeCost++;
        }
        else if (!isUsingBullet1 && !isUsingBullet2 && isUsingBullet3 && pickupAmmount >= damageUpgradeCost)
        {
            return;
        }
    }
}
