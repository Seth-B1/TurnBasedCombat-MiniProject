using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject abilityButton;

    private void Start() 
    {
        InputHandler.onOpenAbilitiesMenu += DisplayUnitAbilities;


    }
    public void DisplayUnitAbilities()
    {
        InfoPanel.SetActive(true);

        PopulateWindowWithAbilities();
    }

    private void PopulateWindowWithAbilities()
    {
        foreach (var ability in InputHandler.currentPlayerUnit.knownAbilities)
        {
            GameObject newbutton = Instantiate(abilityButton, parent: InfoPanel.transform);
            //newbutton.GetComponent<>().text = ability.abilityName;
        }
    }
}
