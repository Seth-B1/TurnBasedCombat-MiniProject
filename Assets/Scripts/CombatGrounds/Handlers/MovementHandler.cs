using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler: MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 startRotation;
    Unit unit;
    private void Start() {
        this.unit = GetComponent<Unit>();
        this.startPosition = unit.transform.position;
        this.startRotation = unit.transform.rotation.eulerAngles;
    }

    public void StopAllGoToIdle()
    {
        if (!unit.isDead)
        {
        unit.anim.SetBool("Run", false);
        }
    }


    public void FaceTarget()
    {
        unit.transform.LookAt(unit.target.transform.position);
    }
        public void FaceForward()
    {
        unit.transform.position = new Vector3 (unit.transform.position.x, 0, unit.transform.position.z);
    }

        public void MoveToTarget(IEnumerator nextAction)
        {
            StartCoroutine(MoveToTarget_Coroutine(nextAction));
        }
        public void ReturnToStartPosition()
        {
            StartCoroutine(ReturnToStartPosition_Coroutine());
        }
        private IEnumerator ReturnToStartPosition_Coroutine()
        {
            unit.agent.isStopped = false;
            Debug.Log($"returning to start position: {startPosition}");
            unit.agent.SetDestination(startPosition);
            while (unit.agent.pathPending)
                yield return null;

            unit.anim.SetBool("Run", true);
            
            Debug.Log(unit.agent.remainingDistance);
            while (unit.agent.remainingDistance >= 0.3f)
            {
                Debug.Log(unit.agent.remainingDistance);
                yield return null;
            }
            unit.anim.SetBool("Run",false);
            unit.transform.position = startPosition;
            unit.transform.rotation = new Quaternion(startRotation.x, startRotation.y, startRotation.z, 1f);
            unit.agent.isStopped = true;
            unit.isExecutingAction = false;
        }

        private IEnumerator MoveToTarget_Coroutine(IEnumerator nextAction)
    {
        //Is spear
        //Is 2HS
        //Is Fists
        //Is onehand
        //Is Ranged
        
        //if at destination stop
        unit.agent.SetDestination(unit.target.transform.position);
        
        while (unit.agent.pathPending)
            yield return null;

        unit.anim.SetBool("Run",true);
        Debug.Log(unit.agent.remainingDistance);

        while (unit.agent.remainingDistance >= 2f)
        {
            yield return null;
        }
        unit.anim.SetBool("Run",false);
        unit.agent.isStopped = true;

        yield return nextAction;
        
    }
    
}
