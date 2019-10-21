using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Input : MonoBehaviour
{
    public Sprite[] inputs;
    public Image imgButton;
    public Image anim;
    public Vector2 offset;
    private Transform follow;
    public Job jobReference;

    public void Init(Transform ToFollow) {
        follow = ToFollow;
        ShowImage(false);
        transform.position = Camera.main.WorldToScreenPoint(follow.position)+ (Vector3)offset;

        jobReference.newInput += ShowInput;
        jobReference.onDetection += ShowImage;
        jobReference.onBeat += ShowAnim;
    }

    private void OnDisable() {
        jobReference.newInput -= ShowInput;
        jobReference.onDetection -= ShowImage;
        jobReference.onBeat -= ShowAnim;
    }

    private void ShowImage(bool show) {
        imgButton.enabled = show;
        anim.enabled = show;
    }

    private void ShowAnim() {
        if(anim.enabled)
            anim.GetComponent<Animator>().SetTrigger("beat");
    }

    private void ShowInput(eINPUT_INTERACT input) {
        switch (jobReference.controller.controllerType) {
            case eCONTROLLER.CONTROLLER:
                imgButton.sprite = inputs[(int)input];
                break;
            case eCONTROLLER.KEYBOARD:
                imgButton.sprite = inputs[(int)input+4];
                break;
        }
    }

}
