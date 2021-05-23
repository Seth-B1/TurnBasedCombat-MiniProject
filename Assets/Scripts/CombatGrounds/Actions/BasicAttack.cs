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
        Debug.Log($"{unit.gameObject.name} executes basic attack");
    }

}
