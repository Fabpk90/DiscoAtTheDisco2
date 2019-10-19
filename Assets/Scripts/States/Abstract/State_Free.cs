using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSTATE_FREE { IDLE, MOVE };

public abstract class State_Free : State_Base
{

    public State_Free(MachineState tMachine) :
        base(tMachine)
    {

    }

    public override void Enter() {
        
    }

    public override void Update() {

    }

    public override void Move(Vector2 direction, float speed) {
        if (!machine.controller.jobPossess) {
            base.Move(direction, speed);
        }
    }

    public override void Interact(eINPUT_INTERACT input) {
        switch (input) {
            case eINPUT_INTERACT.A:
                if(machine.controller.jobInRange.state == eSTATE_WORK.DJ) {
                    machine.ChangeState(new StateWork_DJ(machine));
                }
                break;
        }
    }

    public override void Exit() {

    }
}
