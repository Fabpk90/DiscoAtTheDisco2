using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public enum eINPUT_INTERACT { A, E, SPACE, R};

public struct JobInfo {
    public Job jobObject;
    public bool possess;
}

public class PlayerController : MonoBehaviour
{
    //PARAMETERS
    public float movementSpeed;

    //STORAGE
    private Vector2 movement;
    private PlayerInput inputs;

    //REFERENCES
    public Rigidbody2D rigidBody { get; private set; }
    public Animator animator { get; private set; }
    public MeshRenderer render { get; private set; }

    public JobInfo jobInRange;

    private MachineState machineState;
    private bool possess;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        render = this.GetComponent<MeshRenderer>();

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

    private void OnJobPossess(InputAction.CallbackContext obj)
    {
        possess = !possess;
        print(possess);
        JobPossess(possess);
    }

    private void OnButton4(InputAction.CallbackContext obj)
    {
        
    }

    private void OnButton3(InputAction.CallbackContext obj)
    {
        
    }

    private void OnButton2(InputAction.CallbackContext obj)
    {
        if (jobInRange.jobObject && jobInRange.possess) {
            machineState.Interact(eINPUT_INTERACT.A);
        }
    }

    private void OnButton1(InputAction.CallbackContext obj)
    {
       
    }

    //Called by unity (sendMessage)
    private void OnMovement(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector2>();
        machineState?.Move(movement, movementSpeed);
    }

    private void OnDisable()
    {
        inputs.actions.Disable();
    }
    
    public void JobPossess(bool possess) {
        if (possess)
        {
            if (jobInRange.jobObject && !jobInRange.possess) {
                jobInRange.jobObject.Join(this);
                jobInRange.possess = true;
            }
        } else {
            jobInRange.jobObject.Exit();
            jobInRange.possess = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!jobInRange.jobObject) {
            if (collision.CompareTag("Job")) {
                jobInRange.jobObject = collision.GetComponent<Job>();
                Debug.Log("Assigned jobInRange");
            }
        }
    }
}
