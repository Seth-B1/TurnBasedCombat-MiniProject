using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public Action newAction;
    public static System.Action onOpenAbilitiesMenu;
    [SerializeField]
    public static Unit currentPlayerUnit;
    
    public void BasicAttack_OnClick()
    {
        //StartCoroutine(ChooseTarget());
        currentPlayerUnit.plannedAction = new BasicAttack(InputHandler.currentPlayerUnit);
    }
    public void Abilities_OnClick()
    {
        onOpenAbilitiesMenu();
    }

    public void Items_OnClick()
    {
    }



}
