using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class Unit : MonoBehaviour
{
    public string unitName;
    public List<Ability> knownAbilities;
    public Unit target;
    public Animator anim;
    public NavMeshAgent agent;
    public bool isExecutingAction;
    //public Weapon weapon;
    public int health;
    public int strength;
    public int speed;
    public bool isDead;
    public Action plannedAction;
    public string plannedAbility;
    
    public MovementHandler movementHandler;
    

    public void Start() 
    {
        anim = GetComponent<Animator>();  
        agent = GetComponent<NavMeshAgent>();
        movementHandler = GetComponent<MovementHandler>();
    }

    public void BasicAttack()
    {

    }

    public void Defend()
    {

    }

    public void UseItem()
    {

    }

    public void Die()
    {
        anim.SetTrigger("Die");
        isDead = true;
    }
}
