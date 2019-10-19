using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance { get; private set; }

    [Header("PARAMETERS")]
    public float moodPerSec;

    private float mood;

    private void Awake() {
        if (!instance) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    public void OnPlayerJoined() {
        print("yay a player joined");
    }
    
    void Start()
    {
        mood = 1f;
    }
    
    void Update()
    {
        if(mood > 0) {
            mood -= moodPerSec * Time.deltaTime;
        }
    }

    public float CalculateMood() {
        return mood;
    }

    public void AddMood(float value) {
        mood += value;
    }
}
