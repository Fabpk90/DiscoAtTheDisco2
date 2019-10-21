using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("PARAMETERS")]
    public float waveRefresh;

    [Header("REFERNCES")]
    public Wave waveObject;
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
            yield return new WaitForSeconds(waveRefresh);
            float moodPercentage = 0.0f;
            
            if ( GameManager.instance.CalculateMood() > 0)
            {
                moodPercentage = GameManager.instance.CalculateMood();
            }

            Instantiate<Wave>(waveObject).alpha = moodPercentage;
          

            float increment = Mathf.Floor(GameManager.instance.CalculateMood() * 5);
            for (var i = meteors.Count - 1; i > -1; i--) {
                if (meteors[i] == null)
                    meteors.RemoveAt(i);
            }

            for (int i = meteors.Count-1; i >= 0; --i) {
                if (!meteors[i].Damage((int)increment)) {
                    GameObject tmp = meteors[i].gameObject;
                    meteors.RemoveAt(i);
                    Destroy(tmp);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Meteor")) {
            meteors.Add(collision.GetComponent<Meteor>());
        }
    }
}
