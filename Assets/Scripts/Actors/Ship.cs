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

    private IEnumerator DamageMeteors() {

        while (true)
        {
            wave.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(waveRefresh);
            if ( GameManager.instance.CalculateMood() > 0)
            {
                float moodPercentage = GameManager.instance.CalculateMood() / GameManager.instance.GetMaxMood();
            
                float scale = 2.1f + 4 * moodPercentage;
            
                wave.transform.localScale = new Vector3(scale, scale, 1);
            }
          

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
            
            yield return new WaitForSeconds(waveRefresh);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Meteor")) {
            meteors.Add(collision.GetComponent<Meteor>());
        }
    }
}
