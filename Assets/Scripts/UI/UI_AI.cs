using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AI : MonoBehaviour {

    public Slider imgDrink;
    public Slider imgDirt;
    public Vector2 offset;
    private Transform follow;
    private AI aiReference;

    public void Init(Transform ToFollow) {
        follow = ToFollow;
        aiReference = follow.GetComponent<AI>();
        transform.position = Camera.main.WorldToScreenPoint(follow.position) + (Vector3)offset;
        aiReference.onDestroy += Destroy;
    }

    private void Update() {
        transform.position = Camera.main.WorldToScreenPoint(follow.position) + (Vector3)offset;
        imgDrink.value = aiReference.Drinkyness;
        imgDirt.value = aiReference.Dirtyness;
    }

    private void Destroy() {
        Destroy(gameObject);
    }

    private void OnDisable() {
        aiReference.onDestroy -= Destroy;
    }
}
