using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUI : MonoBehaviour
{
    public GameObject maxedOutDropShips;

    public float timerDropShip;
    public float maxTimerDropShip;

    public bool turnOn;
    public bool startTimer;

    private void Start()
    {
        maxedOutDropShips.SetActive(false);

        turnOn = false;

        timerDropShip = maxTimerDropShip;
    }

    private void Update()
    {
        StartTimer();
        TurnOffMaxedOutPopup();
        TurnOnMaxedOutPopup();

        if (turnOn)
            maxedOutDropShips.SetActive(true);
        else
            maxedOutDropShips.SetActive(false);
    }

    public void TurnOnMaxedOutPopup()
    {

        if (turnOn == true)
        {

            maxedOutDropShips.SetActive(true);

            //timerDropShip = maxTimerDropShip;
            startTimer = true;

        }
    }


    public void TurnOn()
    {
        turnOn = true;
        Debug.Log("Thisworks");
    }

    public void StartTimer()
    {
        if (startTimer)
        {
            timerDropShip -= Time.deltaTime;
        }
    }

    public void TurnOffMaxedOutPopup()
    {
        if (timerDropShip <= 0 )
        {
            startTimer = false;
            turnOn = false;
            maxedOutDropShips.SetActive(false);
        }
    }
}
