﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int playerHealth;
    public int dropShipHealth;
    public int Shields = 3;
    public bool Invincible;

    int PMax;
    int MaxShield;


    public bool isUsingShield1 = true;
    public bool isUsingShield2 = false;
    public bool isUsingShield3 = false;

    public int shieldUpgradeCost;

    public BulletSpawner bSpawn;
    public Pickup playerPickup;

    public GameObject shieldUpgrade2;
    public GameObject shieldUpgrade3;

    public AudioSource aSource;
    public AudioClip explosion;


    public List<GameObject> Lives;
    public GameObject EndScreen;

    public void Start()
    {
        EndScreen = GameObject.Find("End Screen");
        if (EndScreen != null)
        {
            EndScreen.SetActive(false);
        }
        Time.timeScale = 1.0f;
        PMax = playerHealth;
        MaxShield = Shields;
        foreach (GameObject Lifes in GameObject.FindGameObjectsWithTag("Lives"))
        {
            Lives.Add(Lifes);
            for (int i = 0; i < Lives.Count; i++)
            {
                Lives[i].gameObject.SetActive(true);
            }
        }
    }

    public void CurrHealth()
    {
        if (Invincible == false)
        {
            if (Shields > 0)
            {
                Shields--;
            }
            else
            {
                Debug.Log("health lost");
                if (CompareTag("Player"))
                {
                    Debug.Log(playerHealth);
                    int temp = playerHealth - 1;
                    if(temp < 0)
                    {
                        temp = 0;
                    }
                    Lives[temp].SetActive(false);
                    playerHealth--;
                    if (playerHealth <= 0)
                    {
                        Debug.Log("Player dead");

                        aSource.PlayOneShot(explosion);
                        EndScreen.SetActive(true);
                        Time.timeScale = 0.0f;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                    }
                    Invincible = true;
                    Shields = 3;
                    StartCoroutine("InvincibleTick");
                }
                else if (CompareTag("DropShip"))
                {
                    dropShipHealth--;
                    if (dropShipHealth <= 0)
                    {
                        //Debug.Log("Dropship dead");
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    public void Heal()
    {
        playerHealth = PMax;
        for (int i = 0; i < Lives.Count; i++)
        {
            Lives[i].gameObject.SetActive(true);
        }
        Shields = MaxShield;
    }

    private IEnumerator InvincibleTick()
    {
        yield return new WaitForSeconds(3.0f);
        Invincible = false;
    }

    public void ChangeShields()
    {
        if (isUsingShield1 && !isUsingShield2 && !isUsingShield3 && bSpawn.pickupAmmount >= shieldUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(shieldUpgradeCost);

            isUsingShield1 = false;
            isUsingShield2 = true;
            isUsingShield3 = false;

            shieldUpgrade2.SetActive(true);

            shieldUpgradeCost++;
            Shields += 4;
        }
        else if (!isUsingShield1 && isUsingShield2 && !isUsingShield3 && bSpawn.pickupAmmount >= shieldUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(shieldUpgradeCost);

            isUsingShield1 = false;
            isUsingShield2 = false;
            isUsingShield3 = true;

            shieldUpgrade3.SetActive(true);

            shieldUpgradeCost++;
            Shields += 5;
        }
        else if (!isUsingShield1 && !isUsingShield2 && isUsingShield3 && bSpawn.pickupAmmount >= shieldUpgradeCost)
        {
            return;
        }
    }
}
