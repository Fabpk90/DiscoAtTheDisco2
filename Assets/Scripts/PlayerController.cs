using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private MachineState machineState;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        rigidBody = this.GetComponent<Rigidbody2D>();

        inputs.actions.Enable();
        inputs.currentActionMap["Movement"].performed += context => OnMovement(context);
        inputs.currentActionMap["Movement"].canceled += context => OnMovement(context);
        inputs.currentActionMap["Interact"].performed += context => OnInteract(context);

        machineState = new MachineState(this);
    }
    
    private void OnMovement(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector2>();
        machineState?.Move(movement, movementSpeed);
    }

    private void OnInteract(InputAction.CallbackContext value)
    {
        Debug.Log(value.started);
    }

    private void OnDisable()
    {
        inputs.actions.Disable();
    }

    void Update()
    {
        //transform.Translate(movement * Time.deltaTime);
    }
}
