using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Ability", order = 0)]
public class Ability : ScriptableObject 
{
    public string abilityName;
    public bool isHeal;
    public bool isMelee;
    public bool isRanged;
    public bool isMultiTarget;
    public int baseHealValue;
    public int baseDamageValue;

    
}