using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserSlider : MonoBehaviour
{
    public Slider slider;

    public void SetLaserMax(float shield)
    {
        slider.maxValue = shield;
    }

    public void SetLaser(float sheild)
    {
        slider.value = sheild;
    }
}
