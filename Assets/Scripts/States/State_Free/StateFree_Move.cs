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
        machine.controller.animator.SetBool("Move", true);
        machine.controller.animator.SetBool("Iddle", false);
        machine.controller.animator.SetBool("DJ", false);
        machine.controller.animator.SetBool("Bar", false);
        machine.controller.animator.SetBool("Tech", false);
        machine.controller.animator.SetBool("Jacky", false);

    }

    public override void Update() {

    }

    public override void Move(Vector2 direction, float speed) {
        if (speed == 0 || direction == Vector2.zero) {
            machine.ChangeState(new StateFree_Idle(machine));
        } else {
            machine.controller.rigidBody.velocity = direction.normalized * speed;
            if (direction.x < 0)
            {
                machine.controller.GetComponent<SpriteRenderer>().flipX = true;
                machine.controller.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                machine.controller.GetComponent<SpriteRenderer>().flipX = false;
                machine.controller.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    public override void Exit() {
        machine.controller.rigidBody.velocity = Vector2.zero;
    }
}
