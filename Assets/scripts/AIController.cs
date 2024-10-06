using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIController : Controller
{
    [SerializeField] private Pawn pawn;
    
    private Transform target;
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
    public override void ProcessInputs()
    {
        pawn.cursorInput(target.position);
        pawn.Attack();
    }
    
    
    //later I'll set this to target priority whatever has dealt damage to the AI most recently
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
