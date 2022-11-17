using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxTime(float Time)
    {
        slider.maxValue = Time;
    }

    public void SetMinTime(float Time)
    {
        slider.minValue = Time;
        slider.value = Time;
    }
    
    public void setTime(float time)
    {
        slider.value = time;
    }
}
