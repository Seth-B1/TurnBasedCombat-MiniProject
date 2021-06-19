using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastAbility : Action
{
    private Ability _ability;
    public Ability Ability
    {
        get {return _ability;}
        set {_ability = value;}
    }

    public CastAbility(Unit _unit, Ability _ability) : base(_unit)
    {
        Ability = _ability;
    }

    public override void Execute()
    {
        base.Execute();

        if (Ability.isClose)
        {
            unit.StartCoroutine(CastCloseAbility());
        }
    }

    public IEnumerator CastCloseAbility()
    {
        yield return unit.movementHandler.MoveToTarget_Coroutine();

        unit.anim.SetTrigger(Ability.animationName);

        unit.target.health -= Ability.baseDamageValue; 
    }
}
