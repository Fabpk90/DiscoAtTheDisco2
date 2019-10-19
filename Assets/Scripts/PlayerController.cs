using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Vector2 movement;
    private Rigidbody2D rigidBody;
    private PlayerInput inputs;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        
        inputs.actions.Enable();
        inputs.currentActionMap["Movement"].performed += context => OnMovement(context);
    }

    //Called by unity (sendMessage)
    private void OnMovement(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = movement.normalized * speed;
        //transform.Translate(movement * Time.deltaTime);
    }
}
