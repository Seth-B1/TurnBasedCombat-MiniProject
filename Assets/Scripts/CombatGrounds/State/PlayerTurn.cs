using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBCMiniProject.BattleHandler;
public class PlayerTurn : State
{
    public PlayerTurn(BattleHandler _battleHandler) : base(_battleHandler)
    {
    }

#region Enter
    public override IEnumerator Enter()
    {
        Debug.Log("Entering Player Turn");
        battleHandler.inputHandler.onCurrentUnitActionHasBeenChosen += AssignPlannedActionToPlayerUnit;
        
        yield return Main();
    }
#endregion

#region Main
    public override IEnumerator Main()
    {
        Debug.Log("WaitUntilPlayerUnitActionInputAdded");

        yield return WaitUntil_AllPlayerUnitActionInputAdded(); 
    }


    public IEnumerator WaitUntil_AllPlayerUnitActionInputAdded()
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
                battleHandler.playerActionQueue.Add(battleHandler.currentPlayerUnit);
                continue;
            }
            continue;
        }
        yield return ExecuteAllPlayerActionQueue();
    }
    public void AssignPlannedActionToPlayerUnit(object sender, int _action)
    {
        switch (_action)
        {
            case 1:
                battleHandler.currentPlayerUnit.plannedAction = new BasicAttack(battleHandler.currentPlayerUnit);
                break;
            
            default:
                break;
        }
        
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
        }

        yield return Exit();
    }


    #endregion
    
#region Exit  
    public override IEnumerator Exit()
    {
        Debug.Log("Player turn ended");
        battleHandler.inputHandler.onCurrentUnitActionHasBeenChosen -= AssignPlannedActionToPlayerUnit;
        
        battleHandler.ChangeState(new EnemyTurn(battleHandler));
        return null;


    }
#endregion








#region Explanitory Variables (Player Turn)
    private void ChangeCurrentPlayerUnit(Unit playerUnit)
    {
        
        battleHandler.currentPlayerUnit = (PlayerUnit)playerUnit;
        battleHandler.inputHandler.currentPlayerUnit = battleHandler.currentPlayerUnit;
    }
#endregion





}
