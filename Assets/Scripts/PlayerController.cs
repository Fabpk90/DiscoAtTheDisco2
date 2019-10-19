using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        render = this.GetComponent<MeshRenderer>();

        inputs.actions.Enable();
        inputs.currentActionMap["Movement"].performed += context => OnMovement(context);
        inputs.currentActionMap["Movement"].canceled += context => OnMovement(context);

        inputs.currentActionMap["Interact"].started += context => OnInteract(context);
        
        machineState = new MachineState(this);
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        switch (context.action.activeControl.name) {
            case "buttonSouth":
                if (jobInRange.jobObject && !jobInRange.possess) {
                    jobInRange.jobObject.Join(this);
                    jobInRange.possess = true;
                }
                break;
            case "buttonNorth":
                break;
            case "buttonEast":
                if (jobInRange.jobObject && jobInRange.possess) {
                    machineState.Interact(eINPUT_INTERACT.A);
                }
                break;
            case "buttonWest":
                break;
        }
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

    void Update()
    {
    }

    public void JobPossess(bool possess) {
        if (possess) {
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
