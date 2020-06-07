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
}
