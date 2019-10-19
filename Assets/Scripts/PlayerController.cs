using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum eINPUT_INTERACT { A, E, SPACE, R};

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

    public Job jobInRange { get; private set; }
    public bool jobPossess;

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
        print("Button pressed ");
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
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
            if (jobInRange) {
                if (!jobPossess) {
                    jobInRange.Join(this);
                    jobPossess = true;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button1)) {
            if(jobInRange && jobPossess) {
                machineState.Interact(eINPUT_INTERACT.A);
            }
        }
        //transform.Translate(movement * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!jobInRange && !jobPossess) {
            if (collision.CompareTag("Job")) {
                jobInRange = collision.GetComponent<Job>();
                Debug.Log("Assigned jobInRange");
            }
        }
    }
}
