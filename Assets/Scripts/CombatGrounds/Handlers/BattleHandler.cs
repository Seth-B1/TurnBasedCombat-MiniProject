using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
#region Fields and Properties

    public List<Unit> enemyTeam;
    public List<Unit> playerTeam;

    public List<PlayerUnit> playerActionQueue;
#endregion    
    private void Start() 
    {


    }

#region Player Turn Functionality
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
