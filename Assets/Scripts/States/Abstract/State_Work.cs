using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSTATE_WORK { DJ, BARMAN, CLEANER };

public abstract class State_Work : State_Base
{

    public State_Work(MachineState tMachine) :
        base(tMachine)
    {

    }

    public override void Enter() {

    }

    public override void Update() {

    }

    public override void Move(Vector2 direction, float speed) {
        base.Move(direction, speed);
    }

    public override void Interact() {

    }

    public override void Exit() {

    }
}
