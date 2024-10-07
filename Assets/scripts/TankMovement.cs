using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//Can't mess this up, will create a rigidbody if none is present and prevents removal of rigidbody from game object
public class TankMovement : Mover
{
    private TankPawn tankPawn;
    private Rigidbody rb;
    //store the rigidbody as a variable called rb
    private void Awake()
    {
        tankPawn = GetComponent<TankPawn>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //associate the rigidbody component on the tank gameobject with the name rb
    }

    //need to learn about namespaces so I can make these internal
    //movement is is framerate independent with velocity
    public override void ApplyMovement(float verticalInput)
    {
        rb.MovePosition(transform.position + transform.forward * verticalInput * Time.deltaTime * tankPawn.moveSpeed);
    }

    public override void ApplyHullRotation(float horizontalInput)
    {
        transform.Rotate(0, horizontalInput, 0);
    }
}
