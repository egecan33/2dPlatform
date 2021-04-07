using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    public Slider slider;
    public Gradient Gradient;
    public Image fill;

    void Update()
    {
        
    }
    public void SetMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color= Gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }
}
