using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class Unit : MonoBehaviour
{
    public string unitName;
    public Unit target;
    public Animator anim;
    public NavMeshAgent agent;
    public bool isExecutingAction;
    public Weapon weapon;
    public int health;
    public int strength;
    public int speed;
    public bool isDead;
    
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


}
