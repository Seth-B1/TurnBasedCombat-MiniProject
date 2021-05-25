using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBCMiniProject.BattleHandler;
public abstract class State
{
    protected BattleHandler battleHandler;
    
    public State(BattleHandler _battleHandler)
    {
        battleHandler = _battleHandler;
    }
    public virtual IEnumerator Enter()
    {
        yield break;
    }

    public virtual IEnumerator Main()
    {
        yield break;
    }
    public virtual IEnumerator Exit()
    {
        yield break;
    }

}
