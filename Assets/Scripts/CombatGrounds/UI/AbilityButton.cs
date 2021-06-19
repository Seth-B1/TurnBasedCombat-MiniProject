using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public Ability ability;


    public void OnClickAbility()
    {
        InputHandler.currentPlayerUnit.plannedAction = new CastAbility(InputHandler.currentPlayerUnit, ability);
    }
}
