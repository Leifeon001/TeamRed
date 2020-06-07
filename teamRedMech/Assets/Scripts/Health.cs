using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerHealth;
    public int dropShipHealth;
    public int Shields = 3;
    public bool Invincible;
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
}
