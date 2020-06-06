using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public int dropShipsSaved;

    public GameObject cosmeticDropShips;

    // Start is called before the first frame update
    void Start()
    {
        cosmeticDropShips.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddToCarriedDropShips()
    {
        dropShipsSaved++;

        cosmeticDropShips.SetActive(true);
    }

    public void ReduceCarriedDropShips(int ammount)
    {
        dropShipsSaved -= ammount;
    }
}
