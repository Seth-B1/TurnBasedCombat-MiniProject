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

        if (!unit.target.isDead)
        {
            unit.StartCoroutine(BasicAttackTarget());
        }
        else
            unit.isExecutingAction = false;
       
    }

    
    
    public IEnumerator BasicAttackTarget()
    {
        

        yield return unit.movementHandler.MoveToTarget_Coroutine();

        unit.anim.SetTrigger("Left Punch Attack");
        //play unit attack anim
        //Wait 0.5 seconds
        //player target damaged anim
        //Calculate random miss chance

        
        //
        Debug.Log(unit.unitName + " attacks");
        yield return new WaitForSeconds(1f);
        DamageTarget();
        unit.movementHandler.ReturnToStartPosition();
        
    }

    private void DamageTarget()
    {
        
        int totalDamage = 0;

        totalDamage += unit.strength;// + unit.weapon.damage;

        unit.target.health -= totalDamage;
        if (unit.target.health <= 0)
        {
            unit.target.Die();
        }

    }



    #region Test Methods
    public override void TestExecute()
    {
        Debug.Log($"{unit.unitName} executes basic attack");
    }
#endregion
}
