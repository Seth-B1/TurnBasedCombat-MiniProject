using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : ScriptableObject 
{
    public bool ranged;
    public int damage;
    public int durability;
    
}

