using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public int dropShipsSaved;

    public int dropShipMax;

    public bool cantPickUpAnymore;

    public GameObject cosmeticDropShips;

    public AudioSource aSource;
    public AudioClip pickup;


    // Start is called before the first frame update
    void Start()
    {
        cosmeticDropShips.SetActive(false);

        cantPickUpAnymore = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHowManyPods();
    }


    public void CheckHowManyPods()
    {
        if (dropShipsSaved >= dropShipMax)
            cantPickUpAnymore = true;
        else if (dropShipsSaved <= dropShipMax)
            cantPickUpAnymore = false;
    }

    public void AddToCarriedDropShips()
    {
        dropShipsSaved++;

        cosmeticDropShips.SetActive(true);

        aSource.PlayOneShot(pickup);
    }

    public void ReduceCarriedDropShips(int ammount)
    {
        dropShipsSaved -= ammount;
    }
}
