using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //Variable for move speed
    public float moveSpeed;

    //Variable for turn speed
    public float rotationSpeed;


    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }


    public abstract void VerticalInput(float value);
    public abstract void HorizontalInput(float value);

    public abstract void Attack();

    //public abstract void MoveForward();
    //public abstract void MoveBackward();
    //public abstract void RotateClockwise();
    //public abstract void RotateCounterClockwise();

}
