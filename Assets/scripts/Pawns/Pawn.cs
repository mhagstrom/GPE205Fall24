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


    public abstract void VerticalInput();
    public abstract void HorizontalInput();

    //public abstract void MoveForward();
    //public abstract void MoveBackward();
    //public abstract void RotateClockwise();
    //public abstract void RotateCounterClockwise();

}
