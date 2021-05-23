using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Action
{
    public BasicAttack(Unit _unit) : base(_unit)
    {
    }

    public override void Execute()
    {
    }


#region Test Methods
    public override void TestExecute()
    {
        Debug.Log($"{unit.unitName} executes basic attack");
    }
#endregion
}
