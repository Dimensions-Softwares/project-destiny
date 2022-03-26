using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private void Start()
    {
        slider = GetComponent<Slider>();
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
