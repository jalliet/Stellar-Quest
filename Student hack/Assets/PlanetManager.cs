using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour
{
    private bool selectable = false;

    public void Select()
    {
        Debug.Log("SELECTED");
        SceneManager.LoadScene(1);
    }

    internal void Highlight()
    {
    }
}


