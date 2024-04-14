using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FreeViewState : BaseState
{
    public FreeViewState(StateManager stateManager, StateFactory stateFactory) : base(stateManager, stateFactory)
    {
    }

    public override void CheckSwitchState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Changing state");
            stateManager.ChangeState(stateFactory.OverViewState());
        }
    }

    public override void EnterState()
    {
        var planets = GameObject.FindObjectsOfType<OrbitalMovement>();
        foreach (var planet in planets)
        {
            planet.setOrbitFlat(false);
        }
        Debug.Log(stateManager.Target);

        stateManager.FreelookCam.LookAt = stateManager.transform;
        Debug.Log(stateManager.FreelookCam.LookAt.ToString());
        stateManager.FreelookCam.gameObject.SetActive(true);

    }

    public override void ExitState()
    {
        stateManager.FreelookCam.gameObject.SetActive(false);
    }

    public override void UpdateState()
    {
    }
}
