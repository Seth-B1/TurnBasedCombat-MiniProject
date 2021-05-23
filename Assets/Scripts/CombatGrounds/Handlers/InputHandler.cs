using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public Action newAction;
    public Unit currentPlayerUnit;
    public event System.EventHandler onCurrentUnitActionHasBeenChosen;
    public void BasicAttack_SetCurrentUnitAction()
    {
        onCurrentUnitActionHasBeenChosen.Invoke(this, System.EventArgs.Empty);
    }
}
