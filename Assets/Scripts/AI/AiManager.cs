using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiManager : MonoBehaviour
{
    public static AiManager instance;
    
    public int startingDrinkness;
    public int startingDirtyness;

    public float timeBeforeLookForDrink;
    public float timeBeforeLookForDirty;
    
    public AI prefabAI;

    public List<AI> ais;
    public Transform spawnPoint;
    public Transform danceFloorPosition;

    public Transform barPosition;

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
        ai.Dirtyness = startingDirtyness;
        ai.Drinkyness = startingDrinkness;

        ais.Add(ai);
    }
}
