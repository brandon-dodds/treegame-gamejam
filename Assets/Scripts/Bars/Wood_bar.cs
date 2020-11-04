using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood_bar : MonoBehaviour
{
    public Slider slider;

    public void Set_max_wood(int wood)
    {
        slider.maxValue = wood;
        slider.value = wood;
    }
    public void Set_wood(int wood)
    {
        slider.value = wood;
    }
}
