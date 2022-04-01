using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MashBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMash(int mash) {
        slider.maxValue = mash;
        slider.value = mash;
    }

    public void SetMash(int mash) {
        slider.value = mash;
    }
}
