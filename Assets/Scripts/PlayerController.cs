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

    private void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    //Called by unity (sendMessage)
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = movement.normalized * speed;
        //transform.Translate(movement * Time.deltaTime);
    }
}
