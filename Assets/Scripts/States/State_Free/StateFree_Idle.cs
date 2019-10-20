using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFree_Idle : State_Free {

    public StateFree_Idle(MachineState tMachine) :
        base(tMachine)
    {

    }

    public override void Enter() {
        Debug.Log("Entering Idle state");
        machine.controller.rigidBody.velocity = Vector2.zero;
        machine.controller.animator.SetBool("Move", false);
        machine.controller.animator.SetBool("Iddle", true);
        machine.controller.animator.SetBool("DJ", false);
        machine.controller.animator.SetBool("Bar", false);
        machine.controller.animator.SetBool("Tech", false);
        machine.controller.animator.SetBool("Jacky", false);
    }

    public override void Update() {

    }

    public override void Move(Vector2 direction, float speed) {
        if (speed != 0 && direction != Vector2.zero) {
            machine.ChangeState(new StateFree_Move(machine));
        }
    }

    public override void Exit() {

    }
}
