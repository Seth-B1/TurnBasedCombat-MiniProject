using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class BattleHandler : MonoBehaviour
{
#region Fields and Properties
    public PlayerUnit currentPlayerUnit;
    public List<Unit> enemyTeam;
    public List<Unit> playerTeam;

    //Combat
    public List<PlayerUnit> playerActionQueue;
    public InputHandler inputHandler;
#endregion    
    private void Start() 
    {
        inputHandler = GetComponent<InputHandler>();
        inputHandler.onCurrentUnitActionHasBeenChosen += AddPlannedActionToPlayerUnit;
        BeginPlayerTurn();
    }

#region Player Turn Functionality
    void BeginPlayerTurn()
    {
        //CheckIfAllPlayersDead()
        StartCoroutine(WaitUntilPlayerUnitActionInputAdded());
        

    }
    IEnumerator WaitUntilPlayerUnitActionInputAdded()
    {
        Debug.Log("WaitUntilPlayerUnitActionInputAdded");
        foreach (Unit playerUnit in playerTeam)
        {
            if (!playerUnit.isDead)
            {
                ChangeCurrentPlayerUnit(playerUnit);
                while (currentPlayerUnit.plannedAction == null)
                {
                    yield return null;
                }
                playerActionQueue.Add(currentPlayerUnit);
                continue;
            }
            continue;
        }
        ExecutePlayerActionQueue();
    }



    public void AddPlannedActionToPlayerUnit(object sender, System.EventArgs e)
    {
        currentPlayerUnit.plannedAction = new BasicAttack(currentPlayerUnit);
    }
    public void ExecutePlayerActionQueue()
    {
        Debug.Log("All Units added an action, executing now");
        //OrganizeWhoExecutesFirstBySpeed();
        foreach (PlayerUnit playerUnit in playerActionQueue)
        {
            playerUnit.plannedAction.Execute();
        }
    }
    public void NextPlayerAction()
    {
        
    }
#endregion


#region Explanitory Variables (Player Turn)
    private void ChangeCurrentPlayerUnit(Unit playerUnit)
    {
        currentPlayerUnit = (PlayerUnit)playerUnit;
        inputHandler.currentPlayerUnit = currentPlayerUnit;
    }
#endregion
}
