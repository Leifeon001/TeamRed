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
    public float laserTimer;

    public float laserDelayTimerMax;
    public float laserDelayTimer;

    public float laserCDTimerMax;
    public float laserCDTimer;

    private bool startLaserTimer;
    private bool isLaserActive;
    private bool isLaserDelayTimerStarted;

    private bool isLaserOnCooldown = false;

    public bool isUsingBullet1;
    public bool isUsingBullet2;
    public bool isUsingBullet3;

    public GameObject laser;

    public GameObject damageUpgrade2;
    public GameObject damageUpgrade3;

    public Pickup playerPickup;
    public PLaser laserSC;

    public ParticleSystem laserBeam;
    public LaserSlider laserSlider;

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

        damageUpgrade2.SetActive(false);
        damageUpgrade3.SetActive(false);

        laserSlider.SetLaserMax(laserCDTimerMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootProjectile();
        FireLaser();
        StartLaserTimer();
        StartLaserDelayTimer();
        StartLaserCooldown();
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
        if (Input.GetKeyDown(KeyCode.Space) && !laser.activeSelf && isUsingBullet3 && !isLaserOnCooldown)
        {
            Debug.Log("Laser is Fireing");


            laserBeam.Play();

            laserDelayTimer = laserDelayTimerMax;

            laserTimer = laserTimerMax;

            isLaserDelayTimerStarted = true;
        }

    }

    public void StartLaserDelayTimer()
    {
        if (isLaserDelayTimerStarted)
        {
            laserDelayTimer -= Time.deltaTime;

            if (laserDelayTimer <= 0)
            {

                startLaserTimer = true;
                TurnOnLaser();
                isLaserDelayTimerStarted = false;
            }
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

    public void StartLaserCooldown()
    {
        if(isLaserOnCooldown)
        {
            laserCDTimer -= Time.deltaTime;

            laserSlider.SetLaser(laserCDTimer);

            if (laserCDTimer <= 0)
            {
                isLaserOnCooldown = false;
            }
        }
    }

    public void TurnOnLaser()
    {
        laser.SetActive(true);
    }

    public void TurnLaserOff()
    {
        laser.SetActive(false);
        laserTimer = laserTimerMax;
        laserDelayTimer = laserDelayTimerMax;
        startLaserTimer = false;

        isLaserOnCooldown = true;
        laserCDTimer = laserCDTimerMax;
    }

    public void ChangeBullet()
    {
        if (isUsingBullet1 && !isUsingBullet2 && !isUsingBullet3 && pickupAmmount >= damageUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(damageUpgradeCost);

            isUsingBullet1 = false;
            isUsingBullet2 = true;
            isUsingBullet3 = false;

            damageUpgrade2.SetActive(true);

            damageUpgradeCost++;
        }
        else if (!isUsingBullet1 && isUsingBullet2 && !isUsingBullet3 && pickupAmmount >= damageUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(damageUpgradeCost);

            isUsingBullet1 = false;
            isUsingBullet2 = false;
            isUsingBullet3 = true;

            damageUpgrade3.SetActive(true);

            damageUpgradeCost++;
        }
        else if (!isUsingBullet1 && !isUsingBullet2 && isUsingBullet3 && pickupAmmount >= damageUpgradeCost)
        {
            return;
        }
    }
}
