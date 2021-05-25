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
        battleHandler.inputHandler.onCurrentUnitActionHasBeenChosen += AddPlannedActionToPlayerUnit;
        
        yield return null;
        battleHandler.NextStepInState();
    }
#endregion

#region Main
    public override IEnumerator Main()
    {
        Debug.Log("WaitUntilPlayerUnitActionInputAdded");

        yield return WaitUntilPlayerUnitActionInputAdded(); 
    }


    public IEnumerator WaitUntilPlayerUnitActionInputAdded()
    {
        foreach (Unit playerUnit in battleHandler.playerTeam)
        {
            if (!playerUnit.isDead)
            {
                ChangeCurrentPlayerUnit(playerUnit);
                while (battleHandler.currentPlayerUnit.plannedAction == null)
                {
                    yield return null;
                }
                battleHandler.playerActionQueue.Add(battleHandler.currentPlayerUnit);
                continue;
            }
            continue;
        }
        ExecutePlayerActionQueue();
    }
    public void AddPlannedActionToPlayerUnit(object sender, System.EventArgs e)
    {
        battleHandler.currentPlayerUnit.plannedAction = new BasicAttack(battleHandler.currentPlayerUnit);
    }
    public void ExecutePlayerActionQueue()
    {
        //This method needs a coroutine as it needs to wait for each player action to play through
        Debug.Log("All Units added an action, executing now");
        //OrganizeWhoExecutesFirstBySpeed();
        foreach (PlayerUnit playerUnit in battleHandler.playerActionQueue)
        {
            playerUnit.plannedAction.Execute();
        }
    }


    #endregion
    
#region Exit  
    public override IEnumerator Exit()
    {
        return base.Exit();
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
