using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    [SerializeField] private double timeToSpin = 1; // in earth days;

    [SerializeField] private Vector3 rotationAxis;

    public void Update()
    {
        // calculate vector of rotation around y axis based on timetospin
        Vector3 rotationVector = new Vector3(0, 1, 0);


        // rotate this vector so the rotation is around the rotationAxis

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationVector);

    }
}
