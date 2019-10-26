using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiManager : MonoBehaviour
{
    public static AiManager instance;

    public RuntimeAnimatorController[] animators;

    public int maxAI;
    public float secondsBeforeThirst;
    public float rangeBetweenAIs;

    [Range(0f, 1f)]
    public float startingDirtynessHandling;
    
    public float timeBeforeLookForDirty;
    
    public AI prefabAI;

    public List<AI> ais;
    public Transform spawnPoint;
    public float spawnRadius;

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

    private Vector2 GetFreshLocation() {
        int count = 0;
        Vector2 pos = Random.insideUnitCircle * spawnRadius + (Vector2)spawnPoint.position;

        while (TooClose(pos)) {
            ++count;
            if (count == 1500) {
                print("Aborts loop");
                break;
            }
            pos = Random.insideUnitCircle * spawnRadius + (Vector2)spawnPoint.position;
        }
        return pos;
    }

    private bool TooClose(Vector2 pos) {
        foreach(AI ai in ais) {
            if(Vector2.Distance(pos, ai.danceFloorPosition) < rangeBetweenAIs) {
                return true;
            }
        }
        return false;
    }

    public void SpawnAI()
    {
        if (maxAI >= ais.Count)
        {
            AI ai = Instantiate<AI>(prefabAI, spawnPoint.position, Quaternion.identity);
            ai.danceFloorPosition = GetFreshLocation();
            ai.Dirtyness = startingDirtynessHandling;
            ai.Drinkyness = secondsBeforeThirst;
            ai.GetComponent<Animator>().runtimeAnimatorController = animators[(int)UnityEngine.Random.Range(0, animators.Length)];
            ai.GetComponent<Animator>().SetFloat("speed", (Random.Range(0, 3)%2 == 0) ? 1f : .5f);
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
