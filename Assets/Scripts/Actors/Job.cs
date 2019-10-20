using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour
{
    //PARAMETERS
    [Header("PARAMETERS")]
    public float moodWeight;
    public eSTATE_WORK state;
    public eINPUT_INTERACT[] requiredInputs;

    //SOUNDS
    [Header("SOUNDS")]
    public AK.Wwise.Event actionSuccess;
    public AK.Wwise.Event actionFail;
    public AK.Wwise.Event getIn;
    public AK.Wwise.Event getOut;

    //STORAGE
    private int currentInput;

    //REFERENCES
    public PlayerController controller { get; private set; }
    
    void Start()
    {
        currentInput = 0;
    }
    
    void Update()
    {
        //TODO : Should be triggered by a listener to the controller Interact button instead of being called each frame
        //HandleMood();
    }

    private void HandleMood() {
        if (controller) {
            GameManager.instance.AddMood(moodWeight);
        }
    }

    public bool Join(PlayerController tController) {
        if (!controller) {
            controller = tController;
            getIn.Post(gameObject);
            return true;
        }
        return false;
    }

    public void Interact(eINPUT_INTERACT inputTriggered) {
        if(inputTriggered == requiredInputs[currentInput]) {
            if (currentInput < requiredInputs.Length-1) {
                ++currentInput;
                actionSuccess.Post(gameObject);
            } else {
                currentInput = 0;
                actionFail.Post(gameObject);
            }
            GameManager.instance.AddMood(moodWeight);
        }
    }

    public void Exit() {
        if (controller) {
            currentInput = 0;
            controller = null;
            getOut.Post(gameObject);
        }
    }
}
