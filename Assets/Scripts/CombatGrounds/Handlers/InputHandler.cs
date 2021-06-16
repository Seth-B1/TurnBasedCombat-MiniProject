using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public Action newAction;
    public Unit currentPlayerUnit;
    public event System.EventHandler<int> onCurrentUnitActionHasBeenChosen;
    public void BasicAttack_SetCurrentUnitAction()
    {
        onCurrentUnitActionHasBeenChosen.Invoke(this, 1);
    }
    public void Abilities_SetCurrentUnitAction()
    {
        onCurrentUnitActionHasBeenChosen.Invoke(this, 2);
    }
    public void Items_SetCurrentUnitAction()
    {
        onCurrentUnitActionHasBeenChosen.Invoke(this, 3);
    }
}
