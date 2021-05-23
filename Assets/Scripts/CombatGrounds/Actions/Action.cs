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
    }

}
