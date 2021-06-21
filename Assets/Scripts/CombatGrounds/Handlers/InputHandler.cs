using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBCMiniProject.Utilities;
public class InputHandler : MonoBehaviour
{
    public Action newAction;
    public static System.Action onOpenAbilitiesMenu;
    public static Unit currentPlayerUnit;
    public Raycast Raycast;

    private void Start() 
    {
        Raycast = GetComponent<Raycast>();
        
        
    }
    
    public void BasicAttack_OnClick()
    {
        ChooseEnemyTarget(new BasicAttack(InputHandler.currentPlayerUnit));
        
    }
    public void Abilities_OnClick()
    {
        onOpenAbilitiesMenu();
    }

    public void Items_OnClick()
    {
    }


    public void ChooseEnemyTarget(Action newAction)
    {
        StartCoroutine(ChooseEnemyTarget_Coroutine(newAction));
    }
    public IEnumerator ChooseEnemyTarget_Coroutine(Action newAction)
    {
        Debug.Log("Choose a Target");
        
        while (currentPlayerUnit.target == null)
        {
            Raycast.HoverTarget();

            if (Input.GetMouseButtonDown(1))
            {
                currentPlayerUnit.target = Raycast.GetHoveredEnemyUnit() as Unit;
            }
            
            yield return null;
        }

        currentPlayerUnit.plannedAction = newAction;
    }




}
