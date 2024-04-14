using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    protected StateManager stateManager;
    protected StateFactory stateFactory;


    public BaseState(StateManager stateManager, StateFactory stateFactory)
{
        this.stateManager = stateManager;
        this.stateFactory = stateFactory;
}

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void CheckSwitchState();


}
