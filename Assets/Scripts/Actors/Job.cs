using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour
{
    //PARAMETERS
    [Header("PARAMETERS")]
    public float moodWeight;

    //STORAGE
    public eSTATE_WORK state;

    //REFERENCES
    public PlayerController controller { get; private set; }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        //TODO : Should be triggered by a listener to the controller Interact button instead of being called each frame
        HandleMood();
    }

    private void HandleMood() {
        if (controller) {
            GameManager.instance.AddMood(moodWeight);
        }
    }

    public void Join(PlayerController tController) {
        if (!controller) {
            controller = tController;
        }
    }

    public void Exit() {
        if (controller) {
            controller = null;
        }
    }
}
