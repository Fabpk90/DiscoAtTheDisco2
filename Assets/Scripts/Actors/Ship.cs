using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("PARAMETERS")]
    public float waveRefresh;

    [Header("REFERNCES")]
    public GameObject wave;

    //STORAGE
    private List<Meteor> meteors;

    // Start is called before the first frame update
    void Start()
    {
        meteors = new List<Meteor>();
        StartCoroutine(DamageMeteors());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DamageMeteors() {
        wave.transform.localScale = new Vector3(2.33f, 2.33f, 1f);
        yield return new WaitForSeconds(waveRefresh);
        wave.transform.localScale = new Vector3(1f, 1f, 1f);


        int increment = (int)(1/(1 - GameManager.instance.CalculateMood()));


        for (var i = meteors.Count - 1; i > -1; i--) {
            if (meteors[i] == null)
                meteors.RemoveAt(i);
        }

        for (int i = meteors.Count-1; i >= 0; --i) {
            if (!meteors[i].Damage(increment)) {
                GameObject tmp = meteors[i].gameObject;
                meteors.RemoveAt(i);
                Destroy(tmp);
            }
        }
        StartCoroutine(DamageMeteors());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Meteor")) {
            meteors.Add(collision.GetComponent<Meteor>());
        }
    }
}
