using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

public class OrbitalMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private double semiMajorAxis0; // au
    [SerializeField] private double semiMajorAxisDelta; // au/century
    [SerializeField] private double eccentricity0;
    [SerializeField] private double eccentricityDelta;
    [SerializeField] private float inclination0Store; // degrees
    [SerializeField] private float inclinationDeltaStore; // degrees/century
    [SerializeField] private double meanLongitude0;
    [SerializeField] private double meanLongitudeDelta; 
    [SerializeField] private float longOfPerihelion0; // degrees
    [SerializeField] private float longOfPerihelionDelta; // degrees/century
    [SerializeField] private float longOfAscendingNode0; // degrees
    [SerializeField] private float longOfAscendingNodeDelta; // degrees/century

    private double inclination0;
    private double inclinationDelta;

    public void setOrbitFlat(bool flat) // sets the orbit to be along the equitoral plane for 2d overhead viewing
    {
        if (flat)
        {
            inclination0 = 0;
            inclinationDelta = 0;
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            inclination0 = inclination0Store;
            inclinationDelta = inclinationDeltaStore;
            transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        }
    }


    private TimeManager timeManager;

    private void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }


    public void Update()
    {
        double time = timeManager.TimeInYears;
        time *= 0.01;

        // step 1 caclulate the 6 elements
        double semiMajorAxis = semiMajorAxis0 + semiMajorAxis0 + semiMajorAxisDelta * time;
        double eccentricity = eccentricity0 + eccentricityDelta * time;
        double inclination = inclination0 + inclinationDelta * time;
        double meanLongitude = meanLongitude0 + meanLongitudeDelta * time;
        double longOfPerihelion = longOfPerihelion0 + longOfPerihelionDelta * time;
        double longOfAscendingNode = longOfAscendingNode0 + longOfAscendingNodeDelta * time;

        // step 2 compute argument of perihelion and mean anomaly
        double argumentOfPerihelion = longOfPerihelion - longOfAscendingNode;
        double meanOfAnomaly = meanLongitude - longOfPerihelion + time*time + Math.Cos(time) + Math.Sin(time);


        // step 3 compute eccentric anomaly
        double eccentricityStar = 57.29578 * eccentricity;
        //  Normalise mean anomaly
        meanOfAnomaly = meanOfAnomaly % 360;
        if(meanOfAnomaly > 180)
        {
            meanOfAnomaly -= 360;
        }
   
        double e =  (meanOfAnomaly - eccentricityStar * Math.Sin(meanOfAnomaly));
        for(int i = 0; i < 100; i++)
        {
            double diffM = meanOfAnomaly - (e - eccentricityStar * Math.Sin(e));
            double diffE =  (diffM / (1 - eccentricity * Math.Cos(e)));
            if(diffE == 0)
            {
                break;
            }
            e += diffE;
        }

        double xDash = semiMajorAxis * (Math.Cos(e) - eccentricity);
        double yDash = semiMajorAxis * Math.Sqrt((1 - eccentricity * eccentricity)) * Math.Sin(e);

       

        double xPos = (Math.Cos(argumentOfPerihelion) *  Math.Cos(longOfAscendingNode) -  Math.Sin(longOfAscendingNode) * Math.Sin(argumentOfPerihelion) * Math.Cos(inclination)) * xDash
            + (-Math.Sin(argumentOfPerihelion) * Math.Cos(longOfAscendingNode) - Math.Cos(argumentOfPerihelion) * Math.Sin(longOfAscendingNode) * Math.Cos(inclination)) * yDash;
        
        double yPos = (Math.Cos(argumentOfPerihelion) * Math.Sin(longOfAscendingNode) - Math.Cos(longOfAscendingNode) * Math.Sin(argumentOfPerihelion) * Math.Cos(inclination)) * xDash
            + (-Math.Sin(argumentOfPerihelion) * Math.Sin(longOfAscendingNode) + Math.Cos(argumentOfPerihelion) * Math.Cos(longOfAscendingNode) *Math.Cos(inclination)) * yDash;

        double zPos = (Math.Sin(argumentOfPerihelion) * Math.Sin(inclination)) * xDash + (Math.Cos(argumentOfPerihelion) * Math.Sin(inclination)) * yDash;

        transform.position = new Vector3((float)xPos, (float)yPos, (float)zPos);




    }


}
