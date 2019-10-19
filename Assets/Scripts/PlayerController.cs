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

    //REFERENCES
    public Rigidbody2D rigidBody { get; private set; }
    public Animator animator { get; private set; }
    private MachineState machineState;

    private void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        machineState = new MachineState(this);
    }

    //Called by unity (sendMessage)
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        machineState?.Move(movement, movementSpeed);
    }

    void Update()
    {
        //transform.Translate(movement * Time.deltaTime);
    }
}
