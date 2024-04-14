using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory 
{
    private StateManager stateManager;
   public StateFactory(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public BaseState OrbitState()
    {
        return null;
      //  return new OrbitState(stateManager, this);
    }
    public BaseState FreeViewState()
    {
        return new FreeViewState(stateManager, this);
    }
    public BaseState OverViewState()
    {
        return new OverViewState(stateManager, this);
    }
}
