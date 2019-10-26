using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class AI : MonoBehaviour
{
    private SpriteRenderer spRenderer;

    private bool isEntering;
    private bool isLeaving;

    public delegate void tDestroy();
    public event tDestroy onDestroy;

    private float dirtyness;

    public float Dirtyness
    {
        get => dirtyness;
        set => dirtyness = value;
    }
    
    private float drinkyness;

    public float Drinkyness
    {
        get => drinkyness;
        set => drinkyness = value;
    }

    public float moodAmount { get; set; }

    private bool isEnteringBar;

    public Vector3 danceFloorPosition;

    private void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        var color = spRenderer.color;
        color.a = 0;
        spRenderer.color = color;
        isEntering = true;
        isEnteringBar = false;

        //randomize dance floor position
        //danceFloorPosition = (Random.insideUnitCircle * 2.5f + Vector2.one);
    }

    private void Start() {
        UI_Manager.instance.AddAIWidget(transform);
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
        for (int i = 10; i >= 0; i--)
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
                Vector3.MoveTowards(transform.position, danceFloorPosition, 0.05f);

            if ((transform.position - danceFloorPosition).magnitude < 0.5f) {
                isEntering = false;
            }
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
        else
        {
            drinkyness -= Time.deltaTime;
        }
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    IEnumerator LookForADrink()
    {
        //go to the bar, checks if there is enough drink
        //if not drinkyness--;
        while (drinkyness > 0)
        {
            if (drinkyness < AiManager.instance.secondsBeforeThirst / 2)
            {
                while (!isEnteringBar && !isEntering)
                {
                    //Moving towards Bar
                    transform.position = Vector3.MoveTowards(transform.position,
                        AiManager.instance.barPosition.position,
                        0.05f);
                    yield return new WaitForEndOfFrame();
                }
                
                yield return new WaitForSeconds(3.0f);
            }
            
            yield return new WaitForEndOfFrame();
        }

        print("Ai leaving because there's no drink");
        isLeaving = true;
        StartCoroutine(FadeOut());
    }

    IEnumerator CheckTheFloor()
    {
        while (dirtyness > 0)
        {
            yield return new WaitForSeconds(AiManager.instance.timeBeforeLookForDirty);
            
            float percentageDirty =
                AiManager.instance.cleaner.items.Count / (float) AiManager.instance.cleaner.maxItems;

            dirtyness -= percentageDirty * 0.1f;
        }

        print("Ai leaving because it's dirty as fuck");
        isLeaving = true;
        StartCoroutine(FadeOut());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Job_Barman barman = other.gameObject.GetComponent<Job_Barman>();

        if (barman)
        {
            isEnteringBar = true;
            isEntering = true;
            if (barman.items.Count > 0)
            {
                barman.DestroyItem();
                drinkyness = AiManager.instance.secondsBeforeThirst;

                print("drinking");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Job_Barman barman = other.gameObject.GetComponent<Job_Barman>();

        if (barman)
        {
            isEnteringBar = false;
        }
    }

    private void OnDestroy() {
        onDestroy?.Invoke();
    }

    public float GetDrinkPercent() {
        return drinkyness / AiManager.instance.secondsBeforeThirst;
    }
}
