using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLaser : MonoBehaviour
{
    public float damage;

    public float maxDelayTime;
    public float delayTimer;

    public bool startTimer = false;

    public ParticleSystem laserParticle;

    public GameObject laser;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Add Damage here
        }
    }

    private void Update()
    {
        if (startTimer == true)
        {
            delayTimer -= Time.deltaTime;
        }


        if (delayTimer <= 0)
        {
            laser.SetActive(true);

            startTimer = false;
        }
    }

    public void StartDelay()
    {
        laserParticle.Play();

        delayTimer = maxDelayTime;

        startTimer = true;



    }

}
