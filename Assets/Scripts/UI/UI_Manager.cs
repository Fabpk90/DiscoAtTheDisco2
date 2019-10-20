using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public GameObject inputPrefab;

    private void Awake() {
        if (!instance) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }


    public void AddInputWidget(Transform target) {

        UI_Input uiInput = Instantiate(inputPrefab, transform).GetComponent<UI_Input>();
        uiInput.Init(target);
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
