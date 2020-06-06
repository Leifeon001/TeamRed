using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLaser : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Add Damage here
        }
    }
}
