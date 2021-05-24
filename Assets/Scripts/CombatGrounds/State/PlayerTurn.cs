using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(BattleHandler _battleHandler) : base(_battleHandler)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Player Turn begins");
        yield return new WaitForSeconds(0.5f);
    }
}
