using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Job_Cleaner : Job_Spawner
{

    [Header("PARAMETERS")]
    public float itemWeight;
    protected override void Start() {
        base.Start();
    }

    public override void SpawnItem() {

        items.Add(Instantiate(itemPrefab, (Vector2)spawnParent.position + new Vector2(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius)), Quaternion.identity, spawnParent));
        if (items.Count == maxItems) {
            feedback?.SetActive(true);
        }
    }
}
