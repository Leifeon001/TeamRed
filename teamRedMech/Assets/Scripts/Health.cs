using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerHealth;
    public int dropShipHealth;
    public int Shields;
    public void CurrHealth()
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
