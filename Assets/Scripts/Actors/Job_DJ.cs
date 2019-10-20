using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job_DJ : Job
{
    public float valuePerSuccess;
    public float valuePerSec;
    public float efficiency { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    private void Update() {
        if (efficiency > 0) {
            efficiency -= valuePerSec * Time.deltaTime;
        }
    }

    public override eJOB_STATUT Interact(eINPUT_INTERACT inputTriggered) {
        eJOB_STATUT statut = base.Interact(inputTriggered);

        switch (statut) {
            case eJOB_STATUT.SUCCEEDED:
                if(efficiency < 1) {
                    efficiency += (valuePerSuccess > 1-efficiency) ? 1-efficiency : valuePerSuccess;
                    GameManager.instance.AddMood(efficiency / 2);
                }
                break;
        }
        return statut;
    }
}
