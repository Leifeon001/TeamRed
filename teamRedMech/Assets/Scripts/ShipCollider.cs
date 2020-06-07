using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollider : MonoBehaviour
{

    private Pickup playerPickup;

    public PopUpUI popUpUI;
    public bool turnOnTheUI = false;

    public GameObject thisIsMaxed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPickup = other.GetComponent<Pickup>();

            if (!playerPickup.cantPickUpAnymore)
            {
                Debug.Log("Dropship Pickedup");
                playerPickup.AddToCarriedDropShips();

                //turnOnTheUI = false;

                Destroy(this.gameObject);
            }
            else if (playerPickup.cantPickUpAnymore)
            {
                Debug.Log("MaxDropShipsReached");

                ActivateTheUI();

                //turnOnTheUI = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateTheUI()
    {
        thisIsMaxed.SetActive(true);
    }
}
