using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AI : MonoBehaviour
{
    private SpriteRenderer spRenderer;
    

    private bool isEntering;
    private bool isLeaving;

    private int dirtyness;

    public int Dirtyness
    {
        get => dirtyness;
        set => dirtyness = value;
    }
    
    private int drinkyness;

    public int Drinkyness
    {
        get => drinkyness;
        set => drinkyness = value;
    }

    public float moodAmount { get; set; }

    private void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        var color = spRenderer.color;
        color.a = 0;
        spRenderer.color = color;
        isEntering = true;
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(LookForADrink());
        StartCoroutine(CheckTheFloor());
    }

    IEnumerator FadeIn()
    {
        for (int i = 0; i < 10; i++)
        {
            Color color = spRenderer.color;
            color.a = i * 0.1f;

            spRenderer.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut()
    {
        for (int i = 10; i > 0; i--)
        {
            Color color = spRenderer.color;
            color.a = i * 0.1f;

            spRenderer.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntering)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, AiManager.instance.danceFloorPosition.position, 0.05f);

            if ((transform.position - AiManager.instance.danceFloorPosition.position).magnitude < 0.5f)
                isEntering = false;
        }
        else if (isLeaving)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, AiManager.instance.spawnPoint.position, Time.deltaTime);
            if ((transform.position - AiManager.instance.spawnPoint.position).magnitude < 0.5f)
            {
                AiManager.instance.ais.Remove(this);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator LookForADrink()
    {
        //go to the bar, checks if there is enough drink
        //if not drinkyness--;
        while (drinkyness != 0)
        {
            yield return new WaitForSeconds(AiManager.instance.timeBeforeLookForDrink);
            
            while ((transform.position - AiManager.instance.barPosition.position).magnitude > 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, AiManager.instance.barPosition.position,
                    0.05f);
                yield return new WaitForEndOfFrame();
            }
            
            //check here for drink availability
        }

        isLeaving = true;
    }

    IEnumerator CheckTheFloor()
    {
        while (dirtyness != 0)
        {
            yield return new WaitForSeconds(AiManager.instance.timeBeforeLookForDirty);

            //check here for dirty level
        }

        isLeaving = true;
    }
}
