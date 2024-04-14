using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private double timeInYears; // time after J2000
    [SerializeField] private double timeMultiplier = 0.001;
    [SerializeField] private Slider timeMultiplierSlider;

    public double TimeInYears { get { return timeInYears; } }
    public double TimeMultiplier { get { return timeMultiplier; } set { timeMultiplier = Math.Max(value, 0); }  }

    private void Update()
    {
        timeInYears += Time.deltaTime * timeMultiplier;
        timeMultiplier = timeMultiplierSlider.value;
    //    Debug.Log(timeInYears * 365);
    }

}
