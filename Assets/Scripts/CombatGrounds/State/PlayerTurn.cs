using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBCMiniProject.BattleHandler;
using System;

public class PlayerTurn : State
{
    public PlayerTurn(BattleHandler _battleHandler) : base(_battleHandler)
    {
    }

#region Enter
    public override IEnumerator Enter()
    {
        Debug.Log("Entering Player Turn");        
        yield return Main();
    }
#endregion

#region Main
    public override IEnumerator Main()
    {
        Debug.Log("WaitUntilPlayerUnitActionInputAdded");

        yield return GetAllPlayerUnitActionInputs(); 
    }


    public IEnumerator GetAllPlayerUnitActionInputs()
    {
        foreach (Unit activePlayerUnit in battleHandler.playerTeam)
        {
            if (!activePlayerUnit.isDead)
            {
                ChangeCurrentPlayerUnit(activePlayerUnit);
                while (battleHandler.currentPlayerUnit.plannedAction == null)
                {
                    yield return null;
                }
                battleHandler.playerActionQueue.Add(InputHandler.currentPlayerUnit as PlayerUnit);
                continue;
            }
            continue;
        }
        yield return ExecuteAllPlayerActionQueue();
    }

    public IEnumerator ExecuteAllPlayerActionQueue()
    {
        //OrganizeWhoExecutesFirstBySpeed();
        foreach (PlayerUnit playerUnit in battleHandler.playerActionQueue)
        {
            playerUnit.plannedAction.Execute();
            while (playerUnit.isExecutingAction)
            {
                yield return null;
            }
            playerUnit.plannedAction = null;
            playerUnit.target = null;
        }

        ValidateVictoryConditions();
        yield return null;
    }

    private void ValidateVictoryConditions()
    {
        foreach (Unit enemy in battleHandler.enemyTeam)
        {
            if (!enemy.isDead)
            {
                battleHandler.ChangeState(new EnemyTurn(battleHandler));
                break;
            }
        }
        Debug.Log("Enemy team has fallen you are victorious");
    }


    #endregion

    #region Exit  
    public override IEnumerator Exit()
    {
        Debug.Log("Player turn ended");
        
        
        yield return null;

    }
#endregion








#region Explanitory Variables (Player Turn)
    private void ChangeCurrentPlayerUnit(Unit playerUnit)
    {
        
        battleHandler.currentPlayerUnit = (PlayerUnit)playerUnit;
        InputHandler.currentPlayerUnit = battleHandler.currentPlayerUnit;
    }
#endregion





}
