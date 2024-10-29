using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class AIController : Controller
{
    [SerializeField] private Pawn pawn;

    public GameObject target;
    
    public enum AIState
    {
        Idle,
        Chase
    }

    private AIState currentState;
    
    private bool IsDistanceLessThan(GameObject target, float distance)
    {
        return Vector3.Distance(pawn.transform.position, target.transform.position) < distance;
    }

    private void ChangeState(AIState newState)
    {
        currentState = newState;
    }
    
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
    }
    
    //here I provide direct actions in lieu of player input for the AI
    //I need to make this so it only runs with the areaofinterest trigger event from a target entering range of the turret to avoid null reference errors
    public override void ProcessInputs()
    {
        if (target == null) return;
        pawn.cursorInput(target.transform.position);
        pawn.Attack();
        
        
    }


    public void DoIdleState()
    {
        
    }
    public void DoChaseState() 
    {
    if (target == null) return;

    Vector3 directionToTarget = (target.transform.position - pawn.transform.position).normalized;
    pawn.Mover(directionToTarget.z);
    pawn.RotateTowards(target.transform.position); 
    }
    
    //later I'll set this to target priority whatever has dealt damage to the AI most recently
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.Idle:
                // Do work
                DoIdleState();
                // Check for transitions
                if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.Chase:
                // Do work
                DoChaseState();
                // Check for transitions
                if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Idle);
                }
                break;
        }
    }
    
    /* Template
    public void MakeDecisions()
    {
        switch (currentState) {
            case AIState.Idle:
                // Do work 
                DoIdleState();
                // Check for transitions
                if (IsDistanceLessThan(target, 10)) 
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.Chase:
                // Do work
                DoChaseState();
                // Check for transitions
                if (!IsDistanceLessThan(target, 10)) {
                    ChangeState(AIState.Idle);
                }
                break;
        }
    }*/
    
}
