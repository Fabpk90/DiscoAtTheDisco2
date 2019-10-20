using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFree_Move : State_Free
{

    public StateFree_Move(MachineState tMachine) :
        base(tMachine) {

    }

    public override void Enter() {
        Debug.Log("Entering Move state");
    }

    public override void Update() {

    }

    public override void Move(Vector2 direction, float speed) {
        if (speed == 0 || direction == Vector2.zero) {
            machine.ChangeState(new StateFree_Idle(machine));
        } else {
            machine.controller.rigidBody.velocity = direction.normalized * speed;
        }
    }

    public override void Exit() {

    }
}
