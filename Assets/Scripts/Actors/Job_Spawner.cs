﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job_Spawner : Job
{
    [Header("PARAMETERS")]
    public int maxItems;
    public GameObject itemPrefab;
    public GameObject feedback;
    public bool spawnIfSucceed;
    
    //STORAGE
    public List<GameObject> items { get; protected set; }

    //REFERENCES
    [SerializeField]
    protected Transform spawnParent;
    public float spawnRadius;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        items = new List<GameObject>();
    }

    public override eJOB_STATUT Interact(eINPUT_INTERACT inputTriggered) {
        eJOB_STATUT statut = base.Interact(inputTriggered);
        switch (statut) {
            case eJOB_STATUT.SUCCEEDED:
                if (spawnIfSucceed) {
                    if (items.Count < maxItems) {
                        SpawnItem();
                    }
                } else {
                    if(items.Count > 0) {
                        DestroyItem();
                    }
                }
                break;
        }
        return statut;
    }

    public virtual void SpawnItem() {
        items.Add(Instantiate(itemPrefab, (Vector2)spawnParent.position + Random.insideUnitCircle * spawnRadius, Quaternion.identity, spawnParent));
        if(items.Count == maxItems) {
            feedback?.SetActive(true);
        }
    }

    public void DestroyItem() {
        if (items.Count == maxItems) {
            feedback?.SetActive(false);
        }
        GameObject tmp = items[0];

        items.RemoveAt(0);
        Destroy(tmp);
    }
}
