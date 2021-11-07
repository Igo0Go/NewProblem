using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTank : MonoBehaviour
{
    [SerializeField, Range(0,100)] private float oxygenValue;

    public float OxygenValue
    {
        get
        {
            return oxygenValue;
        }
        set
        {
            oxygenValue = value;
            oxygenValueSlider.value = value;
        }
    }

    [SerializeField] private Slider oxygenValueSlider;

    private void Start()
    {
        OxygenValue = oxygenValue;
    }
}
