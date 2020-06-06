using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform player;
    public CharacterController move;
    public float speed = 1f;
    public float forward;
    public float sideways;
    

    // Update is called once per frame
    void Update()
    {
        CharacterMove(); 
    }

    void CharacterMove()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.y = 0;
        forward = Input.GetAxis("Vertical");
        sideways = Input.GetAxis("Horizontal");
        Vector3 characterMovement = new Vector3(sideways, 0, forward);
        characterMovement *= speed;
        move.Move(characterMovement * Time.deltaTime);
        player.LookAt(mousePosition);
    }
}
