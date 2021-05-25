using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBCMiniProject.BattleHandler;
public class BeginBattle : State
{
    public BeginBattle(BattleHandler _battleHandler) : base(_battleHandler)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log("A new battle has begun");

        yield return new WaitForSeconds(1f);
        battleHandler.ChangeState(new PlayerTurn(this.battleHandler));
    }
    
    public override IEnumerator Main()
    {
        return base.Main();
    }
    public override IEnumerator Exit()
    {
        return base.Exit();
    }
}
