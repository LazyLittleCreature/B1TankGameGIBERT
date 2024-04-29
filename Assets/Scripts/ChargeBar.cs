using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxChargeTime(float ChargeTime)
    {
        slider.maxValue = ChargeTime;
        slider.value = ChargeTime;
    }

    public void SetChargeTime(float ChargeTime)
    {
        slider.value = ChargeTime;
    }
}
