using System.Collections;
using System.Collections.Generic;
using TBCMiniProject.BattleHandler;
using UnityEngine;

public class EnemyTurn : State
{
    public EnemyTurn(BattleHandler _battleHandler) : base(_battleHandler)
    {
    }

    public override IEnumerator Enter()
    {
        Debug.Log("Begin Enemy Turn");
        return null;
    }

    public override IEnumerator Main()
    {
        yield break;
    }
    public override IEnumerator Exit()
    {
        yield break;
    }
}
