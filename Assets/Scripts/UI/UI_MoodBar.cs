using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MoodBar : MonoBehaviour
{
    public Slider moodBar;
    
    void Update()
    {
        moodBar.maxValue = GameManager.instance.GetMaxMood();
        moodBar.value = GameManager.instance.CalculateMood();
    }
}
