using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public string unitName;
    public Unit target;
    public Weapon weapon;
    public int health;
    public int strength;
    public int speed;
    public bool isDead;
    

    public void BasicAttack()
    {

    }

    public void Defend()
    {

    }

    public void UseItem()
    {

    }


}
