using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiManager : MonoBehaviour
{
    public static AiManager instance;

    public int maxAI;
    public float secondsBeforeThirst;

    [Range(0f, 1f)]
    public float startingDirtynessHandling;
    
    public float timeBeforeLookForDirty;

    public AI prefabAI;

    public List<AI> ais;
    public Transform spawnPoint;

    public Transform barPosition;

    public Job_Cleaner cleaner;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            SpawnAI();
        }
            
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnAI()
    {
        AI ai = Instantiate<AI>(prefabAI, spawnPoint.position, Quaternion.identity);
        ai.Dirtyness = startingDirtynessHandling;
        ai.Drinkyness = secondsBeforeThirst;

        ais.Add(ai);
    }
}
