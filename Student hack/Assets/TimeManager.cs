using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private double timeInYears; // time after J2000
    private float timeMultiplier = 0.01f;

    public double TimeInYears { get { return timeInYears; } }
    public float TimeMultiplier { get { return timeMultiplier; } set { timeMultiplier = Mathf.Max(value, 0); }  }

    private void Update()
    {
        timeInYears += Time.deltaTime * timeMultiplier;
        Debug.Log(timeInYears);
    }

}
