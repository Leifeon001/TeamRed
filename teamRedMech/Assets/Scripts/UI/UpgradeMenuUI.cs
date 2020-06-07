using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUI : MonoBehaviour
{
    public bool ableToTurnOn = false;

    public GameObject upgradeMenu;

    public Text damageText;

    public BulletSpawner bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ToggleUpgradeMenu();

        DrawDamageCost();
    }

    /*public void ToggleUpgradeMenu()
    {
        if(Input.GetKeyDown(KeyCode.I) && !isMenuOn)
        {
            upgradeMenu.SetActive(true);
            isMenuOn = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isMenuOn)
        {
            
            isMenuOn = false;
            Time.timeScale = 1f;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UpgradeTrigger")
        {

        }

    }

    public void TurnOffUpgradeMenu()
    {
       upgradeMenu.SetActive(false);
    }

    public void DrawDamageCost()
    {
        if (!bulletSpawner.isUsingBullet3)
            damageText.text = bulletSpawner.damageUpgradeCost.ToString();
        else if (bulletSpawner.isUsingBullet3)
            damageText.text = "Maxed!"; 

    }
}
