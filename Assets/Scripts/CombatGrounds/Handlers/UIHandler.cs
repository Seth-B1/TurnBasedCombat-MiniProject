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
        AbilityButton.onCloseAbilitiesMenu += CloseUnitAbilities;

    }
    public void DisplayUnitAbilities()
    {
        if (InfoPanel.activeSelf == true)
            return;


        InfoPanel.SetActive(true);
        PopulateWindowWithAbilities();
    }

    public void CloseUnitAbilities()
    {
        foreach (Transform button in InfoPanel.transform)
            Destroy(button.gameObject);      
        
        InfoPanel.SetActive(false);  
    }

    private void PopulateWindowWithAbilities()
    {
        foreach (var ability in InputHandler.currentPlayerUnit.knownAbilities)
        {
            GameObject newbutton = Instantiate(abilityButton, parent: InfoPanel.transform);
            newbutton.transform.GetChild(0).GetComponent<Text>().text = ability.abilityName;
            newbutton.GetComponent<AbilityButton>().ability = ability;
        }
    }
}
