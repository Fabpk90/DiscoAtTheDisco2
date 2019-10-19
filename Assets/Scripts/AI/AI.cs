using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AI : MonoBehaviour
{
    private SpriteRenderer spRenderer;

    private float moodAmount;

    public float MoodAmount
    {
        get => moodAmount;
        set => moodAmount = value;
    }

    public Transform danceFloorPosition;
    private Vector3 spawningPosition;

    private bool isEntering;

    private void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        var color = spRenderer.color;
        color.a = 0;
        spRenderer.color = color;
        isEntering = true;

        spawningPosition = transform.position;
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
        moodAmount -= GameManager.instance.moodPerSec * Time.deltaTime;
        if (isEntering)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, danceFloorPosition.position, Time.deltaTime);

            if ((transform.position - danceFloorPosition.position).magnitude < 0.5f)
                isEntering = false;
        }

        if (moodAmount < 0)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, spawningPosition, Time.deltaTime);
            if ((transform.position - danceFloorPosition.position).magnitude < 0.5f)
            {
                AiManager.instance.ais.Remove(this);
                Destroy(gameObject);
            }
        }
    }
}
