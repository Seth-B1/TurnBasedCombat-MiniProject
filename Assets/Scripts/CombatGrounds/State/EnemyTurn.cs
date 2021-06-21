using System;
using System.Collections;
using System.Collections.Generic;
using TBCMiniProject.BattleHandler;
using UnityEngine;

public class EnemyTurn : State
{
    public EnemyTurn(BattleHandler _battleHandler) : base(_battleHandler)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log("Begin Enemy Turn");

        yield return Main();
    }

    public override IEnumerator Main()
    {
        foreach (EnemyUnit enemy in battleHandler.enemyTeam)
        {
            
            DetermineEnemyAction(enemy);
        }

        yield return ExecuteEnemyActionQueue();
    }

    

    public override IEnumerator Exit()
    {
        Debug.Log("Enemy turn over");
        yield break;
    }

    private IEnumerator ExecuteEnemyActionQueue()
    {
        foreach (EnemyUnit enemy in battleHandler.enemyActionQueue)
        {
            enemy.plannedAction.Execute();
            while (enemy.isExecutingAction)
            {
                yield return null;
            }
            
            enemy.plannedAction = null;
            enemy.target = null;
        }
        //If players are still alive
        battleHandler.ChangeState(new PlayerTurn(battleHandler));
        yield return null;
    }


    private void DetermineEnemyTarget(EnemyUnit _enemy)
    {
        //Algorithim to determine who is the enemies target
        //For now just use math random

        int random = UnityEngine.Random.Range(0, battleHandler.playerTeam.Count);
        _enemy.target = battleHandler.playerTeam[random];
    }
    private void DetermineEnemyAction(EnemyUnit _enemy)
    {
        DetermineEnemyTarget(_enemy);
        //If HP is low and has healing Item use that
        //If Energy is high enough cast hardest hitting ability
        //If energy is low roll dice to determine if they should consume energy recovery
        _enemy.plannedAction = new BasicAttack(_enemy);

        battleHandler.enemyActionQueue.Add(_enemy);

    }
}
