using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWork_DJ : State_Work
{

    public StateWork_DJ(MachineState tMachine) :
        base(tMachine)
    {

    }

    public override void Enter() {
        machine.controller.render.material.color = Color.blue;
    }

    public override void Update() {

    }

    public override void Move(Vector2 direction, float speed) {
        base.Move(direction, speed);
    }

    public override void Interact(eINPUT_INTERACT input) {
        if(input == eINPUT_INTERACT.BT1) {
        }
    }

    public override void Exit() {

    }
}
