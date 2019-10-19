using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    public Slider healthBar;

    void Update() {
        healthBar.value = GameManager.instance.hp;
    }
}
