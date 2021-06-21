using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public Unit unit;
    public Action(Unit _unit)
    {
        unit = _unit;
    }
    
    public virtual void Execute()
    {
        unit.isExecutingAction = true;        
    }

    public virtual void EndOfAction()
    {
        unit.plannedAction = null;
        unit.target = null;

        if (unit.TryGetComponent<PlayerUnit>(out PlayerUnit playerUnit))
        {
            playerUnit.isReady = false;
        }
    }

    
#region Testing Methods
    public virtual void TestExecute()
    {
    }
#endregion
    

}
