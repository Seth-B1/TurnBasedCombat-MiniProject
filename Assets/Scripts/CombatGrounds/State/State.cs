using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected BattleHandler battleHandler;

    public State(BattleHandler _battleHandler)
    {
        battleHandler = _battleHandler;
    }
    public virtual IEnumerator Start()
    {   
        yield break;
    }
    public virtual IEnumerator BasicAttack()
    {   
        yield break;
    }
    
    public virtual IEnumerator Exit()
    {   
        yield break;
    }



}
