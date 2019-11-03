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
    public Transform playerPos;
    //STORAGE
    protected int currentInput;
    protected bool canPerform;

    //REFERENCES
    public PlayerController controller { get; private set; }

    public delegate void Detection(bool enter);
    public event Detection onDetection;

    public delegate void Input(eINPUT_INTERACT input);
    public event Input onInteract; 
    public event Input newInput;

    public delegate void BeatMusic();
    public event BeatMusic onBeat;

    //SOUNDS
    [Header("SOUNDS")]
    public AK.Wwise.Event actionSuccessSound;
    public AK.Wwise.Event actionNextSound;
    public AK.Wwise.Event actionFailSound;
    public AK.Wwise.Event getInSound;
    public AK.Wwise.Event getOutSound;

    private void OnEnable() {
    }

    private void OnDisable() {
        GameManager.instance.onMusicBeat -= InputWindow;
    }

    protected virtual void Start() {

        currentInput = 0;
        UI_Manager.instance.AddInputWidget(this,playerPos.transform);
        GameManager.instance.onMusicBeat += InputWindow;
    }

    public bool Join(PlayerController tController) {
        if (!controller) {

            onDetection?.Invoke(true);
            controller = tController;
            controller.GetComponent<SpriteRenderer>().flipX = false;
            controller.transform.position = playerPos.position;
            controller.animator.SetBool("Move", false);
            controller.animator.SetBool("Iddle", false);
            controller.animator.SetBool("DJ", false);
            controller.animator.SetBool("Bar", false);
            controller.animator.SetBool("Tech", false);
            controller.animator.SetBool("Jacky", false);
            switch (state) {
                case eSTATE_WORK.BARMAN:
                    controller.animator.SetBool("Bar", true);
                    break;
                case eSTATE_WORK.CLEANER:
                    controller.animator.SetBool("Tech", true);
                    break;
                case eSTATE_WORK.DJ:
                    controller.animator.SetBool("DJ", true);
                    break;
                case eSTATE_WORK.JACKY:
                    controller.animator.SetBool("Jacky", true);
                    break;
            }

            newInput?.Invoke(requiredInputs[currentInput]);
            getInSound.Post(gameObject);
            return true;
        }
        return false;
    }

    public virtual eJOB_STATUT Interact(eINPUT_INTERACT inputTriggered) {
        eJOB_STATUT statut;

        if (canPerform) {
            onInteract?.Invoke(inputTriggered);
            if (inputTriggered == requiredInputs[currentInput]) {
                if (currentInput < requiredInputs.Length - 1) {
                    ++currentInput;
                    newInput?.Invoke(requiredInputs[currentInput]);
                    statut = eJOB_STATUT.NEXT;
                    actionNextSound.Post(gameObject);
                } else {
                    currentInput = 0;
                    newInput?.Invoke(requiredInputs[currentInput]);
                    statut = eJOB_STATUT.SUCCEEDED;
                    actionSuccessSound.Post(gameObject);
                }
            } else {
                statut = eJOB_STATUT.FAILED;
                actionFailSound.Post(gameObject);
            }
        } else {
            statut = eJOB_STATUT.FAILED;
            actionFailSound.Post(gameObject);
        }

        Debug.Log(statut);

        return statut;
    }

    public void Exit() {
        if (controller) {
            currentInput = 0;
            controller = null;
            onDetection?.Invoke(false);
            getOutSound.Post(gameObject);
        }
    }

    private void InputWindow() {
        onBeat?.Invoke();
        canPerform = true;
        StartCoroutine(NewDelay());
    }

    private IEnumerator NewDelay() {
        yield return new WaitForSeconds(0.25f);

        canPerform = false;
    }
}
