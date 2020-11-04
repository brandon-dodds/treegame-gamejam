using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Growth_bar : MonoBehaviour
{
    public Slider slider;

    public void Set_max_growth(float growth)
    {
        slider.maxValue = growth;
        slider.value = growth;
    }
    public void Change_growth(float growth)
    {
        slider.value = growth;
    }
}
