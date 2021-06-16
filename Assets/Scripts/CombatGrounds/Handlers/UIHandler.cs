using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject InfoPanel;
    public InputHandler inputHandler;

    private void Start() 
    {
        inputHandler = GetComponent<InputHandler>();
    }
    public void DisplayUnitAbilities()
    {
        foreach (Ability ability in inputHandler.currentPlayerUnit.knownAbilities)
        {

        }
    }
}
