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
        enemyTeam = new List<Unit>();  
        playerTeam = new List<Unit>();
        //playerActionQueue = new List<PlayerUnit>();
    }

#region Player Turn Functionality
    public void ExecutePlayerActionQueue()
    {
        foreach (PlayerUnit unit in playerActionQueue)
        {
            unit.plannedAction.Execute();
        }
    }
    public void NextPlayerAction()
    {
        
    }
#endregion
    
}
