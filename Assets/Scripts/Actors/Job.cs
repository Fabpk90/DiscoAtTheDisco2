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

    public delegate void Detection(bool enter);
    public event Detection onDetection;

    public delegate void Input(eINPUT_INTERACT input);
    public event Input onInteract; 
    public event Input newInput; 
    
    protected virtual void Start() {
        
        currentInput = 0;
        UI_Manager.instance.AddInputWidget(transform);
    }

    public bool Join(PlayerController tController) {
        if (!controller) {
            onDetection?.Invoke(true);
            controller = tController;
            getIn.Post(gameObject);
            newInput?.Invoke(requiredInputs[currentInput]);
            return true;
        }
        return false;
    }

    public virtual eJOB_STATUT Interact(eINPUT_INTERACT inputTriggered) {
        onInteract?.Invoke(inputTriggered);
        eJOB_STATUT statut;
        if (inputTriggered == requiredInputs[currentInput]) {
            if (currentInput < requiredInputs.Length-1) {
                ++currentInput;
                newInput?.Invoke(requiredInputs[currentInput]);
                actionSuccess.Post(gameObject);
                statut = eJOB_STATUT.NEXT;
            } else {
                currentInput = 0;
                newInput?.Invoke(requiredInputs[currentInput]);
                actionFail.Post(gameObject);
                statut = eJOB_STATUT.SUCCEEDED;
            }
        } else {
            statut = eJOB_STATUT.FAILED;
        }

        Debug.Log(statut);

        return statut;
    }

    public void Exit() {
        if (controller) {
            currentInput = 0;
            controller = null;
            onDetection?.Invoke(false);
            getOut.Post(gameObject);
        }
    }
}
