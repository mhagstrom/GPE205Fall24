using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : Pawn
{
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //this is directly controlled until AI is fully implemented
        LookAtTarget();
    }
    
    private void LookAtTarget()
    {
        //this will be used to rotate the turret towards the target
    }
    public override void VerticalInput(float value)
    {
        
    }

    public override void HorizontalInput(float value)
    {
        
    }

    public override void Attack()
    {
        
    }
}
