using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiManager : MonoBehaviour
{
    public static AiManager instance;
    
    public int startingDrinkness;
    public int startingDirtyness;
    
    public AI prefabAI;

    public List<AI> ais;
    public Transform spawnPoint;
    public Transform danceFloorPosition;
    
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
        ai.danceFloorPosition = danceFloorPosition;

        ais.Add(ai);
    }

    public float TotalMood()
    {
        float totalMood = 0.0f;

        foreach (AI ai in ais)
        {
            totalMood += (ai.Dirtyness + ai.Drinkyness);
        }
        
        if(ais.Count != 0)
            return totalMood / ais.Count;
        else
            return 0;
    }

    public float GetMaxMood()
    {
        return ais.Count * (startingDirtyness + startingDrinkness);
    }
}
