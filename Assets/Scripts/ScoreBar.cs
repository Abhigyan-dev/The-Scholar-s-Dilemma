using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{

    public Slider slider;
    
    public void SetMaxScore(int score)
    {
        slider.maxValue = score;
    }

    public void SetMinScore(int score)
    {
        slider.minValue = score;
        slider.value = score;
    }

    public void setScore(int score)
    {
        slider.value = score;
    }
}
