using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance { get; private set; }

    [Header("PARAMETERS")]
    public float moodPerSec;
    public float meteorPerSec;
    public float[] meteorScales;

    [Header("REFERENCES")]
    public GameObject meteor;

    //STORAGE
    private float mood;
    public float hp { get; private set; }

    private void Awake() {
        if (!instance) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnMeteor());
        mood = 1f;
        hp = 1f;
    }
    
    void Update()
    {
        if(mood > 0) {
            mood -= moodPerSec * Time.deltaTime;
        }
    }

    public IEnumerator SpawnMeteor() {
        yield return new WaitForSeconds(1/meteorPerSec);
        Spawn();
        StartCoroutine(SpawnMeteor());
    }

    public float CalculateMood() {
        return mood * AiManager.instance.ais.Count;
    }

    public void AddMood(float value) {
        mood = Mathf.Clamp01(mood + value);
    }

    public void ApplyDamages(float value) {
        hp -= value;
    }

    [ContextMenu("Spawn")]
    public void Spawn() {
        Vector3 spawnPoint = FindPoint(Vector3.zero, 25f, Random.Range(0, 360));
        GameObject tmp = Instantiate(meteor, spawnPoint, Quaternion.identity, transform);
        
        tmp.GetComponent<Meteor>().Init(-spawnPoint.normalized, 15f, 2);
    }

    [ContextMenu("Clear")]
    public void Clear() {
        foreach (var item in transform.GetComponentsInChildren<Transform>()) {
            if (item != transform)
                DestroyImmediate(item.gameObject);
        }
    }

    Vector3 FindPoint(Vector3 center, float radius, int angle) {
        return center + Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * radius);
    }
}
