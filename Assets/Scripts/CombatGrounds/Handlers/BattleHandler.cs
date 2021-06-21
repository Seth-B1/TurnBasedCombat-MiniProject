using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace TBCMiniProject.BattleHandler
{
    
public class BattleHandler : MonoBehaviour
{
#region Fields and Properties
    public PlayerUnit currentPlayerUnit;
    public List<Unit> enemyTeam;
    public List<Unit> playerTeam;

    //Combat
    public List<PlayerUnit> playerActionQueue;
    public List<EnemyUnit> enemyActionQueue;
    public InputHandler inputHandler;
    //
    //States
    public State currentState;
    public bool isBattleOver;
#endregion    
    private void Start() 
    {
        
        inputHandler = GetComponent<InputHandler>();
        
        
        currentState = new BeginBattle(this);
        StartCoroutine(currentState.Enter());
    }

#region State Handling (Change to Class?)

    public void ChangeState(State newState)
    {
        StopAllCoroutines();

        playerActionQueue.Clear();
        enemyActionQueue.Clear();
        
        StartCoroutine(currentState.Exit());
        
        currentState = newState;
        StartCoroutine(currentState.Enter());
    }    
#endregion


}
}