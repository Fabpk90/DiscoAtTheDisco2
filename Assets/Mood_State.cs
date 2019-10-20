using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mood_State : MonoBehaviour
{

    private float currentMood;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentMood = GameManager.instance.CalculateMood() / GameManager.instance.GetMaxMood();

        if (currentMood < 0.1f)
        {
            AkSoundEngine.SetState("Mood", "Mood_Level_00");
        }
        if (currentMood >= 0.1f && currentMood < 0.40f)
        {
            AkSoundEngine.SetState("Mood", "Mood_Level_01");
        }
        if (currentMood >= 0.40f && currentMood < 0.70f)
        {
            AkSoundEngine.SetState("Mood", "Mood_Level_02");
        }
        if (currentMood >= 0.70)
        {
            AkSoundEngine.SetState("Mood", "Mood_Level_03");
        }
    }
}
