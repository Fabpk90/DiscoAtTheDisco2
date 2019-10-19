using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineState
{
    public PlayerController controller { get; private set; }
    private State_Base currentState;

    public MachineState(PlayerController tController) {
        controller = tController;
        ChangeState(new StateFree_Idle(this));
    }

    public void Update() {
        currentState.Update();
    }

    public void Move(Vector2 direction, float speed) {
        currentState.Move(direction, speed);
    }

    public void Interact() {

    }

    public void ChangeState(State_Base newState) {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
