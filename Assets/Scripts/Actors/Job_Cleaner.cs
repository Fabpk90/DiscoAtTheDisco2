using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job_Cleaner : Job_Spawner
{

    [Header("PARAMETERS")]
    public float itemWeight;

    protected override void Start() {
        base.Start();
        items = new List<GameObject>();
        for (int i = 0; i < 8; ++i) {
            SpawnItem();
        }
    }
}
