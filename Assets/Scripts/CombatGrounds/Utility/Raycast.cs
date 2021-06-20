using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBCMiniProject.Utilities
{
    
public class Raycast : MonoBehaviour
{

    
    public Unit GetHoveredEnemyUnit()
    {
        //camera = Camera.main;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) 
        {
            if (hit.transform.tag == "Enemy")
            {
                return hit.transform.GetComponent<EnemyUnit>();
            }
            return null;
        }
        return null;
    }

        public void HoverTarget()
        {
            
        }
    }
}