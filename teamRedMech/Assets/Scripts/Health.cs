using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerHealth;
    public int dropShipHealth;
    public int Shields = 3;
    public bool Invincible;

    public bool isUsingShield1 = true;
    public bool isUsingShield2 = false;
    public bool isUsingShield3 = false;

    public int shieldUpgradeCost;

    public BulletSpawner bSpawn;
    public Pickup playerPickup;

    public GameObject shieldUpgrade2;
    public GameObject shieldUpgrade3;

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
                    playerHealth--;
                    if (playerHealth <= 0)
                    {
                        Debug.Log("Player dead");
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
                        Debug.Log("Dropship dead");
                    }
                }
            }
        }
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
