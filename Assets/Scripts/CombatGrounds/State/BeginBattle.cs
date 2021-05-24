using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBattle : State
{
    public BeginBattle(BattleHandler _battleHandler) : base(_battleHandler)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("A battle has begun");
        
        yield return new WaitForSeconds(1f);

        battleHandler.SetState(new PlayerTurn(this.battleHandler));
    }
}
