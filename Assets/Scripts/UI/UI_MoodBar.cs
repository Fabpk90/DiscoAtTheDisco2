using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MoodBar : MonoBehaviour
{
    public Slider moodBar;
    
    void Update()
    {
        moodBar.maxValue = AiManager.instance.GetMaxMood();
        moodBar.value = AiManager.instance.TotalMood();
    }
}
