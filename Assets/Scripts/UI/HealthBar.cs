using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider; //Cursor to modify the health value
    [SerializeField] private Gradient gradient; //To change color of health bar
    [SerializeField] private Image fill; //actual color of the Bar

    private void Awake()
    {
        slider = GetComponent<Slider>();
        GameManager.Instance.RegisterHealthBar(this);
    }

    public void SetMaxHealth(int value)
    {
        slider.maxValue = value;
    }

    public void SetHealth(int value)
    {
        slider.value = value;
        SetBarColor(slider.normalizedValue);
    }

    private void SetBarColor(float value)
    {
        fill.color = gradient.Evaluate(value);
    }

}
