﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiManager : MonoBehaviour
{
    public static AiManager instance;

    public RuntimeAnimatorController[] animators;

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
        }else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        for(int i = 0; i < maxAI; i++) {
            //SpawnAI();
        }
    }

    public void SpawnAI()
    {
        if (maxAI >= ais.Count)
        {
            AI ai = Instantiate<AI>(prefabAI, spawnPoint.position, Quaternion.identity);
            ai.Dirtyness = startingDirtynessHandling;
            ai.Drinkyness = secondsBeforeThirst;
            ai.GetComponent<Animator>().runtimeAnimatorController = animators[(int)UnityEngine.Random.Range(0, animators.Length)];
            ai.GetComponent<Animator>().SetFloat("speed", .25f);
            ais.Add(ai);
        }
        
    }

    public float GetTotalMood() {
        float tmp = 0f;

        foreach(AI ai in ais) {
            tmp += ai.moodAmount;
        }

        return tmp;
    }
}
