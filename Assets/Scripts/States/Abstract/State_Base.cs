using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSTATE { FREE, WORK }

public abstract class State_Base
{
    protected MachineState machine;

    public State_Base(MachineState tMachine)
    {
        machine = tMachine;
    }

    public virtual void Enter() {

    }

    public virtual void Update() {

    }

    public virtual void Move(Vector2 direction, float speed) {
        machine.controller.rigidBody.velocity = direction.normalized * speed;
    }

    public virtual void Interact(eINPUT_INTERACT input) {
    }

    public virtual void Exit() {

    }
}
