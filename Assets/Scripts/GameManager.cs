using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance { get; private set; }

    [Header("PARAMETERS")]
    public float junkPerSec;
    public float meteorPerSec;
    public float[] meteorScales;

    [Header("REFERENCES")]
    public GameObject meteor;
    public Job_Cleaner cleaner;
    public Job_DJ DJ;

    [Header("SOUND")]
    public AK.Wwise.RTPC hpRTPC;

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
        StartCoroutine(SpawnJunk());
        hp = 1f;
    }
    
    void Update() {

        mood = ( CalculateMood() <= 1f) ? CalculateMood() : 1f;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        hpRTPC.SetGlobalValue(hp);
    }

    private IEnumerator SpawnJunk() {
        yield return new WaitForSeconds(1/junkPerSec*AiManager.instance.ais.Count);
        cleaner.SpawnItem();
        StartCoroutine(SpawnJunk());
    }

    public IEnumerator SpawnMeteor() {
        yield return new WaitForSeconds(1/meteorPerSec);
        Spawn();
        StartCoroutine(SpawnMeteor());
    }

    public float CalculateMood() {
        return AiManager.instance.ais.Count/GetMaxMood() * DJ.efficiency;
    }

    public float GetMaxMood()
    {
        return AiManager.instance.maxAI;
    }

    public void ApplyDamages(float value) {
        hp -= value;
        if(hp <= 0) {
            SceneManager.LoadScene(1);
            StopAllCoroutines();
        }
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
