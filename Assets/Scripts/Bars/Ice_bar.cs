﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ice_bar : MonoBehaviour
{
    public Slider slider;

    public void Set_max_ice(int ice)
    {
        slider.maxValue = ice;
        slider.value = ice;
    }
    public void Set_ice(int ice)
    {
        slider.value = ice;
    }
}
