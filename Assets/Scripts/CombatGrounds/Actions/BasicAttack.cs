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
        
        //unit.movement.FaceTarget();
        //unit.movement.MoveToTarget_Melee();
        BasicAttackTarget();
        
    }

    
    
    void BasicAttackTarget()
    {
        int totalDamage = 0;

        totalDamage += unit.strength + unit.weapon.damage;

        //play unit attack anim
        //Wait 0.5 seconds
        //player target damaged anim
        //Calculate random miss chance

        unit.target.health -= totalDamage;
        //
        Debug.Log(unit.unitName + " attacks for damage: " + totalDamage);
        
    }
    


#region Test Methods
    public override void TestExecute()
    {
        Debug.Log($"{unit.unitName} executes basic attack");
    }
#endregion
}
