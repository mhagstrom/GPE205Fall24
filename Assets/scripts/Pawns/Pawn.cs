using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    protected Mover mover;
    protected Shooter shooter;
    protected Health health;
    
    //Variable for move speed
    public float moveSpeed;

    //Variable for turn speed
    public float rotationSpeed;

    //variable for attack rate
    public float attackRate;
    
    //for aicontroller to use
    public abstract void RotateTowards(Vector3 targetPosition);
    
    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }


    public abstract void Mover(float f);

    public abstract void Attack();

    //this will be used to rotate the turret towards the target by faking cursor input with target location
    public abstract void cursorInput(Vector3 value);

}
