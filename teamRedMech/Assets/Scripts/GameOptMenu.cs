using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptMenu : MonoBehaviour
{
    public GameObject OptPanel;
    bool OptOpen;

    
   public void ExitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && OptOpen == false)
        {
            OptOpen = true;
            OptPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape)&& OptOpen == true)
        {
            OptOpen = false;
            OptPanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
