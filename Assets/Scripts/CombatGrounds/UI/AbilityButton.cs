using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AbilityButton : MonoBehaviour
{
    public Ability ability;
    public static System.Action onCloseAbilitiesMenu;
    
    public void OnClickAbility()
    {
        InputHandler.currentPlayerUnit.plannedAction = new CastAbility(InputHandler.currentPlayerUnit, ability);
        
        onCloseAbilitiesMenu();

        
    }
}
