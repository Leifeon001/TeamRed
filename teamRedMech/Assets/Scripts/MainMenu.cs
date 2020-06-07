using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptPanel;
    bool isOptOpen;
    public GameObject CredPanel;
    bool isCredOpen;
    public float RotSpeed = 1.2f;

    public void Options() //click Options panel on/off
    {
       if(isOptOpen == false)
        {

            isOptOpen = true;
            OptPanel.SetActive(true);
            isCredOpen = false;
            CredPanel.SetActive(false);

        }
        else if (isOptOpen == true)
        {
            isOptOpen = false;
            OptPanel.SetActive(false);
        }
        
    }

    public void Credits() //click Options panel on/off
    {
        if(isCredOpen == false)
        {
            isCredOpen = true;
            CredPanel.SetActive(true);
            isOptOpen = false;
            OptPanel.SetActive(false);
        }
        else if (isCredOpen == true)
        {
            isCredOpen = false;
            CredPanel.SetActive(false);

        }
    }
    
    public void PlayGame() //Start Playing game
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame() //Exit game
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        //Rotate skybox
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotSpeed);
    }
}
