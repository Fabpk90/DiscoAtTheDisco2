using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AI : MonoBehaviour
{
    private SpriteRenderer spRenderer;
    

    private bool isEntering;

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

    // Update is called once per frame
    void Update()
    {
       
        if (isEntering)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, AiManager.instance.danceFloorPosition.position, Time.deltaTime);

            if ((transform.position - AiManager.instance.danceFloorPosition.position).magnitude < 0.5f)
                isEntering = false;
        }
        else if (drinkyness < 0 || dirtyness < 0)
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
        yield return null;
    }

    IEnumerator CheckTheFloor()
    {
        yield return null;
    }
}
