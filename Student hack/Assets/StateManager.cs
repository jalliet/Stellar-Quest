using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] GameObject startTarget;

    protected BaseState currentState;
    protected StateFactory stateFactory;

    [SerializeField] private CinemachineVirtualCamera overviewcam;
    [SerializeField] private CinemachineFreeLook freelookCam;
    [SerializeField] public LayerMask planetMask;


    private GameObject target;

    public CinemachineVirtualCamera OverviewCam { get { return overviewcam; } }
    public CinemachineFreeLook FreelookCam { get { return freelookCam; } }
    public GameObject Target { get { return target; } }


    
    
    void Awake()
    {
        stateFactory = new StateFactory(this);
        currentState = stateFactory.FreeViewState();
        currentState.EnterState();
        
        target = startTarget;
        Debug.Log(Target);

        
    }

    void Update()
    {
        currentState.CheckSwitchState();
        currentState.UpdateState();
    }

    public void ChangeState(BaseState state)
    {
       
        Debug.Log("ADA");
        currentState.ExitState();
        Debug.Log("Exit");
        currentState = state;
        Debug.Log("Change");
        currentState.EnterState();
        Debug.Log("State successfully changed");
    }
}
