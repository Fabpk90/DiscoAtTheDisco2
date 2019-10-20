using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eJOB_STATUT { FAILED, SUCCEEDED, NEXT };
public enum eSTATE_WORK { DJ, BARMAN, CLEANER, JACKY };

public class Job : MonoBehaviour
{
    //PARAMETERS
    [Header("PARAMETERS")]
    public eSTATE_WORK state;
    public eINPUT_INTERACT[] requiredInputs;

    //SOUNDS
    [Header("SOUNDS")]
    public AK.Wwise.Event actionSuccess;
    public AK.Wwise.Event actionFail;
    public AK.Wwise.Event getIn;
    public AK.Wwise.Event getOut;

    //STORAGE
    protected int currentInput;

    //REFERENCES
    public PlayerController controller { get; private set; }
    
    protected virtual void Start() {
        
        currentInput = 0;
    }

    public bool Join(PlayerController tController) {
        if (!controller) {
            controller = tController;
            getIn.Post(gameObject);
            return true;
        }
        return false;
    }

    public virtual eJOB_STATUT Interact(eINPUT_INTERACT inputTriggered) {
        if(inputTriggered == requiredInputs[currentInput]) {
            if (currentInput < requiredInputs.Length-1) {
                ++currentInput;
                actionSuccess.Post(gameObject);
                return eJOB_STATUT.NEXT;
            } else {
                currentInput = 0;
                actionFail.Post(gameObject);
                return eJOB_STATUT.SUCCEEDED;
            }
        }
        return eJOB_STATUT.FAILED;
    }

    public void Exit() {
        if (controller) {
            currentInput = 0;
            controller = null;
            getOut.Post(gameObject);
        }
    }
}
