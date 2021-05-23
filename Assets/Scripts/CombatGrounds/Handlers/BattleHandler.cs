using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        inputHandler = new InputHandler();
    }

#region Player Turn Functionality
    void BeginPlayerTurn()
    {
        foreach (Unit playerUnit in playerTeam)
        {
            if (!playerUnit.isDead)
            {
                currentPlayerUnit = (PlayerUnit)playerUnit;
                StartCoroutine(WaitForPlayerUnitActionInput());
                continue;
            }
            continue;
        }
    }
    IEnumerator WaitForPlayerUnitActionInput()
    {
        while (currentPlayerUnit.plannedAction == null)
        {
            yield return null;
        }
        playerActionQueue.Add(currentPlayerUnit);
    }

    public void ExecutePlayerActionQueue()
    {
        foreach (PlayerUnit playerUnit in playerActionQueue)
        {
            playerUnit.plannedAction.Execute();
        }
    }
    public void NextPlayerAction()
    {
        
    }
#endregion
    
}
