using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job_Jacky : Job
{
    public float permissionRate;
    public int nbSpawnPermitted;

    //REFERENCES
    [SerializeField]
    private Transform spawnParent;

    protected override void Start() {
        base.Start();
        StartCoroutine(SpawnPermission());
    }

    public override eJOB_STATUT Interact(eINPUT_INTERACT inputTriggered) {
        eJOB_STATUT statut = base.Interact(inputTriggered);

        switch (statut) {
            case eJOB_STATUT.SUCCEEDED:
                if (nbSpawnPermitted > 0) {
                    AiManager.instance.SpawnAI();
                    --nbSpawnPermitted;
                }
                break;
        }
        return statut;
    }

    private IEnumerator SpawnPermission() {
        yield return new WaitForSeconds(permissionRate);
        ++nbSpawnPermitted;
        StartCoroutine(SpawnPermission());
    }
}
