using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform player;
    public CharacterController move;
    public float speed;
    public float forward;
    public float sideways;

    public bool isUsingSpeed1 = true;
    public bool isUsingSpeed2;
    public bool isUsingSpeed3;

    public int speedUpgradeCost;

    public BulletSpawner bSpawn;
    public Pickup playerPickup;

    public GameObject speedUpgrade2;
    public GameObject speedUpgrade3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }       
        CharacterMove();                    
    }

    void CharacterMove()
    {
        //transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
   
        //mousePosition.y = 0;
        forward = Input.GetAxis("Vertical");
        sideways = Input.GetAxis("Horizontal");
        Vector3 characterMovement = new Vector3(0, 0, forward);
        characterMovement = transform.TransformDirection(characterMovement);       
        characterMovement *= speed;       
        move.Move(characterMovement * Time.deltaTime * speed);       
        transform.Rotate(0, sideways, 0);
        // player.LookAt(mousePosition);
    }

    public void ChangeSpeed()
    {
        if (isUsingSpeed1 && !isUsingSpeed2 && !isUsingSpeed3 && bSpawn.pickupAmmount >= speedUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(speedUpgradeCost);

            isUsingSpeed1 = false;
            isUsingSpeed2 = true;
            isUsingSpeed3 = false;

            speedUpgrade2.SetActive(true);

            speedUpgradeCost++;
            speed++;
        }
        else if (!isUsingSpeed1 && isUsingSpeed2 && !isUsingSpeed3 && bSpawn.pickupAmmount >= speedUpgradeCost)
        {
            playerPickup.ReduceCarriedDropShips(speedUpgradeCost);

            isUsingSpeed1 = false;
            isUsingSpeed2 = false;
            isUsingSpeed3 = true;

            speedUpgrade3.SetActive(true);

            speedUpgradeCost++;
            speed++;
        }
        else if (!isUsingSpeed1 && !isUsingSpeed2 && isUsingSpeed3 && bSpawn.pickupAmmount >= speedUpgradeCost)
        {
            return;
        }
    }
}
