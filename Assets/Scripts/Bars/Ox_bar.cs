using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ox_bar : MonoBehaviour
{
    public Slider slider;

    public void Set_max_02(int ox)
    {
        slider.maxValue = ox;
        slider.value = ox;
    }

    public void Set_02(int ox)
    {
        slider.value = ox;
    }
}
