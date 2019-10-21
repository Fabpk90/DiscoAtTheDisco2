using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public GameObject inputPrefab;
    public GameObject ai_ui_Prefab;

    private void Awake() {
        if (!instance) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }


    public void AddInputWidget(Job job, Transform target) {

        UI_Input uiInput = Instantiate(inputPrefab, transform).GetComponent<UI_Input>();
        uiInput.jobReference = job;
        uiInput.Init(target);
    }

    public void AddAIWidget(Transform target) {

        UI_AI uiAI = Instantiate(ai_ui_Prefab, transform).GetComponent<UI_AI>();
        uiAI.Init(target);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
