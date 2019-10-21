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
    public Job_Cleaner cleaner;
    public Job_Barman barman;
    public Job_DJ DJ;

    //STORAGE
    public float mood { get; private set; }
    public float hp { get; private set; }

    public delegate void Beat();
    public event Beat onMusicBeat;

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
        StartCoroutine(SpawnDrink());
        //StartCoroutine(SpawnJunk());
        hp = 1f;
    }
    
    void Update()
    {
        if(mood > 0) {
            //Calculate Psy power
            print(CalculateMood());
            float decPsyPower = 1-CalculateMood();

            mood -= moodPerSec * decPsyPower * Time.deltaTime;
            mood += CalculateMood() * DJ.efficiency * Time.deltaTime;
            print(DJ.efficiency);
        }
    }

    private IEnumerator SpawnJunk() {
        yield return new WaitForSeconds(5f);
        cleaner.SpawnItem();
        StartCoroutine(SpawnJunk());
    }

    private IEnumerator SpawnDrink() {
        yield return new WaitForSeconds(0.5f);
        barman.SpawnItem();
        StartCoroutine(SpawnDrink());
    }

    public IEnumerator SpawnMeteor() {
        yield return new WaitForSeconds(1/meteorPerSec);
        Spawn();
        StartCoroutine(SpawnMeteor());
    }

    public float CalculateMood() {
        return AiManager.instance.ais.Count/GetMaxMood();
    }

    public float GetMaxMood()
    {
        return AiManager.instance.maxAI;
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

    public void MusicBeat() {
        onMusicBeat?.Invoke();
    }
}
