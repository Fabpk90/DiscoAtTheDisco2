using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Input : MonoBehaviour
{
    public Sprite[] inputs;
    public Image imgButton;
    private Transform follow;
    private Job jobReference;

    public void Init(Transform ToFollow) {
        follow = ToFollow;
        jobReference = follow.GetComponent<Job>();
        transform.position = Camera.main.WorldToScreenPoint(follow.position);

        jobReference.newInput += ShowInput;
    }

    private void OnDisable() {
        jobReference.newInput -= ShowInput;
    }

    private void ShowImage(bool show) {
        imgButton.enabled = show;
    }

    private void ShowInput(eINPUT_INTERACT input) {
        imgButton.sprite = inputs[(int)input];
    }

}
