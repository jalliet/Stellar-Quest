using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverViewState : BaseState
{
    public OverViewState(StateManager stateManager, StateFactory stateFactory) : base(stateManager, stateFactory)
    {
    }

    public override void CheckSwitchState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.ChangeState(stateFactory.FreeViewState());
        }
    }

    public override void EnterState()
    {
        var planets = GameObject.FindObjectsOfType<OrbitalMovement>();
        foreach (var planet in planets)
        {
            planet.setOrbitFlat(true);
        }

        stateManager.OverviewCam.gameObject.SetActive(true);
    }

    public override void ExitState()
    {
        stateManager.OverviewCam.gameObject.SetActive(false);
    }

    public override void UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast ray and highlight planet
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction, out hit, stateManager.planetMask))
            {
                try
                {
                    hit.collider.gameObject.GetComponentInParent<PlanetManager>().Select();
                }
                catch
                {

                }

            }
        }

    }
}
