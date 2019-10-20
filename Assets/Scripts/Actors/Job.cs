using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eJOB_STATUT { FAILED, SUCCEEDED, NEXT };

public class Job : MonoBehaviour
{
    //PARAMETERS
    [Header("PARAMETERS")]
    public float moodWeight;
    public eSTATE_WORK state;
    public eINPUT_INTERACT[] requiredInputs;

    //STORAGE
    protected int currentInput;

    //REFERENCES
    public PlayerController controller { get; private set; }
    
    void Start()
    {
        currentInput = 0;
    }

    private void HandleMood() {
        if (controller) {
            GameManager.instance.AddMood(moodWeight);
        }
    }

    public bool Join(PlayerController tController) {
        if (!controller) {
            controller = tController;
            return true;
        }
        return false;
    }

    public virtual eJOB_STATUT Interact(eINPUT_INTERACT inputTriggered) {
        if(inputTriggered == requiredInputs[currentInput]) {
            if (currentInput < requiredInputs.Length-1) {
                ++currentInput;

                return eJOB_STATUT.NEXT;
            } else {
                currentInput = 0;

                return eJOB_STATUT.SUCCEEDED;
            }
        }
        return eJOB_STATUT.FAILED;
    }

    public void Exit() {
        if (controller) {
            currentInput = 0;
            controller = null;
        }
    }
}
