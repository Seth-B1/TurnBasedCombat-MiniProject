using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{

    public List<Unit> enemyTeam;
    public List<Unit> playerTeam;

    public List<PlayerUnit> playerActionQueue;
    
    private void Start() 
    {
        enemyTeam = new List<Unit>();  
        playerTeam = new List<Unit>();
        //playerActionQueue = new List<PlayerUnit>();
        ExecutePlayerActionQueue();
    }

#region playerturn
    public void ExecutePlayerActionQueue()
    {
        foreach (PlayerUnit unit in playerActionQueue)
        {
            unit.plannedAction.Execute();
        }
    }
#endregion
    
}
