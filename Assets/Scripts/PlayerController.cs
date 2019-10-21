using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public enum eINPUT_INTERACT { BT1, BT2, BT3, BT4};
public enum eCONTROLLER { KEYBOARD, CONTROLLER };

public struct JobInfo {
    public Job jobObject;
    public bool possess;
}

public class PlayerController : MonoBehaviour
{
    //PARAMETERS
    public float movementSpeed;
    private static int nbplayer = 0;

    //STORAGE
    private Vector2 movement;
    private PlayerInput inputs;
    public eCONTROLLER controllerType { get; private set; }

    //REFERENCES
    public Rigidbody2D rigidBody { get; private set; }
    public Animator animator { get; private set; }
    public SpriteRenderer render { get; private set; }

    public JobInfo jobInRange;

    private MachineState machineState;
    private bool possess;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        render = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();

        inputs.actions.Enable();
        inputs.currentActionMap["Movement"].performed += context => OnMovement(context);
        inputs.currentActionMap["Movement"].canceled += context => OnMovement(context);

        inputs.currentActionMap["Button1"].started += OnButton1;
        inputs.currentActionMap["Button2"].started += OnButton2;
        inputs.currentActionMap["Button3"].started += OnButton3;
        inputs.currentActionMap["Button4"].started += OnButton4;

        possess = false;

        inputs.currentActionMap["PossessJob"].started += OnJobPossess;

        machineState = new MachineState(this);
        
    }
    private void Start()
    {
        switch (nbplayer)
        {
            case 0:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 1:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                break;
            default:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
        }
        
        ++nbplayer;
    }

    private void OnJobPossess(InputAction.CallbackContext obj)
    {
        InitControllerType(obj);
        if (jobInRange.jobObject)
        {
            if (!jobInRange.possess) {
                Debug.Log("Possess job");
                jobInRange.jobObject.Join(this);
                jobInRange.possess = true;
                machineState.ChangeState(new State_Work(machineState));
            }
            else
            {
                jobInRange.jobObject.Exit();
                jobInRange.possess = false;
            }
        }
    }

    private void OnButton4(InputAction.CallbackContext obj) {
        InitControllerType(obj);
        if (jobInRange.jobObject && jobInRange.possess) {
            machineState.Interact(eINPUT_INTERACT.BT4);
        }
    }

    private void OnButton3(InputAction.CallbackContext obj) {
        InitControllerType(obj);
        if (jobInRange.jobObject && jobInRange.possess) {
            machineState.Interact(eINPUT_INTERACT.BT3);
        }
    }

    private void OnButton2(InputAction.CallbackContext obj) {
        InitControllerType(obj);
        if (jobInRange.jobObject && jobInRange.possess) {
            machineState.Interact(eINPUT_INTERACT.BT2);
        }
    }

    private void OnButton1(InputAction.CallbackContext obj) {
        InitControllerType(obj);
        if (jobInRange.jobObject && jobInRange.possess) {
            machineState.Interact(eINPUT_INTERACT.BT1);
        }
    }

    private void InitControllerType(InputAction.CallbackContext obj) {
        controllerType = (obj.control.ToString().Contains("Keyboard") ? eCONTROLLER.KEYBOARD : eCONTROLLER.CONTROLLER);
    }

    //Called by unity (sendMessage)
    private void OnMovement(InputAction.CallbackContext value) {
        InitControllerType(value);
        movement = value.ReadValue<Vector2>();
        machineState?.Move(movement, movementSpeed);
    }

    private void OnDisable()
    {
        inputs.actions.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!jobInRange.jobObject) {
            if (collision.CompareTag("Job")) {
                jobInRange.jobObject = collision.GetComponent<Job>();
                Debug.Log("Assigned jobInRange");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (jobInRange.jobObject) {
            if (collision.CompareTag("Job")) {
                jobInRange.jobObject.Exit();
                jobInRange.jobObject = null;
                Debug.Log("Removed jobInRange");
            }
        }
    }
}
