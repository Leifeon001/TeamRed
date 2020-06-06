using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGraphics : MonoBehaviour
{
  public void Graphics(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void FullScreen (bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void WindowScreen(bool isWindow)
    {

    }
}
