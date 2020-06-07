using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUI : MonoBehaviour
{
    public bool isMenuOn;
    public bool canTurnOn;

    public GameObject upgradeMenu;
    public GameObject popUp;

    public Text damageText;

    public Text speedText;

    public Text shieldText;

    public BulletSpawner bulletSpawner;
    public CharacterMovement cMovement;
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOn = false;
        canTurnOn = false;

        popUp.SetActive(false);

        upgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleUpgradeMenu();

        DrawDamageCost();

        DrawSpeedCost();

        DrawShieldCost();
    }

    public void ToggleUpgradeMenu()
    {
        if(Input.GetKeyDown(KeyCode.I) && !isMenuOn && canTurnOn)
        {
            upgradeMenu.SetActive(true);
            isMenuOn = true;
            //Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isMenuOn && canTurnOn)
        {
            upgradeMenu.SetActive(false);
            isMenuOn = false;
            //Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UpgradeDock")
        {
            //Debug.Log("Welcome to the upgradebay!");

            popUp.SetActive(true);

            canTurnOn = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "UpgradeDock")
        {
            popUp.SetActive(false);

            canTurnOn = false;
        }

    }

    public void TurnOnUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
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

    public void DrawSpeedCost()
    {
        if (!cMovement.isUsingSpeed3)
            speedText.text = cMovement.speedUpgradeCost.ToString();
        else if (cMovement.isUsingSpeed3)
            speedText.text = "Maxed!";

    }

    public void DrawShieldCost()
    {
        if (!health.shieldUpgrade3)
            shieldText.text = health.shieldUpgradeCost.ToString();
        else if (health.shieldUpgrade3)
            shieldText.text = "Maxed!";

    }
}
