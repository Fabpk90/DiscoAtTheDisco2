using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)Mathf.Floor(Random.value * sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
