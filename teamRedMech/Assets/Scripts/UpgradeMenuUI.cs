using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUI : MonoBehaviour
{
    public bool isMenuOn;

    public GameObject upgradeMenu;

    public Text damageText;

    public BulletSpawner bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOn = false;

        upgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleUpgradeMenu();

        DrawDamageCost();
    }

    public void ToggleUpgradeMenu()
    {
        if(Input.GetKeyDown(KeyCode.I) && !isMenuOn)
        {
            upgradeMenu.SetActive(true);
            isMenuOn = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isMenuOn)
        {
            upgradeMenu.SetActive(false);
            isMenuOn = false;
            Time.timeScale = 1f;
        }
    }

    public void DrawDamageCost()
    {
        if (!bulletSpawner.isUsingBullet3)
            damageText.text = bulletSpawner.damageUpgradeCost.ToString();
        else if (bulletSpawner.isUsingBullet3)
            damageText.text = "Maxed!"; 

    }
}
