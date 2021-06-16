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
        unit.isExecutingAction = true;
        
        //unit.movementHandler.FaceTarget();
        
        //unit.movement.MoveToTarget_Melee();
        unit.StartCoroutine(BasicAttackTarget());
        
    }

    
    
    public IEnumerator BasicAttackTarget()
    {
        yield return unit.movementHandler.MoveToTarget_Coroutine();

        int totalDamage = 0;

        totalDamage += unit.strength;// + unit.weapon.damage;

        unit.anim.SetTrigger("Left Punch Attack");
        //play unit attack anim
        //Wait 0.5 seconds
        //player target damaged anim
        //Calculate random miss chance

        //unit.target.health -= totalDamage;
        //
        Debug.Log(unit.unitName + " attacks for damage: " + totalDamage);
        yield return new WaitForSeconds(1f);
        unit.movementHandler.ReturnToStartPosition();
    }
    


#region Test Methods
    public override void TestExecute()
    {
        Debug.Log($"{unit.unitName} executes basic attack");
    }
#endregion
}
