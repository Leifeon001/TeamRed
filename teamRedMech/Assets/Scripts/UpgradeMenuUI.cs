using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUI : MonoBehaviour
{
    public bool isMenuOn;

    public GameObject upgradeMenu;

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
}
