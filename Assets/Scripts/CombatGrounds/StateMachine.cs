using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State State;

    public virtual void SetState(State state)
    {
        if (State != null)
        {
            State.Exit();
        }
        State = state;
        StartCoroutine(State.Start());

    }

}
