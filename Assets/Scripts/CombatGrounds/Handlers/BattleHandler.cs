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
    public InputHandler inputHandler;
    //
    //States
    public State currentState;
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
        StartCoroutine(currentState.Exit());
        
        currentState = newState;
        StartCoroutine(currentState.Enter());
    }

    public void NextStepInState()
    {
        Debug.Log("Next Step in state");
        StartCoroutine(currentState.Main());
    }
    
#endregion


}
}