using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//Can't mess this up, will create a rigidbody if none is present and prevents removal of rigidbody from game object
public class TankMovement : MonoBehaviour
{
    private Rigidbody rb;
    //store the rigidbody as a variable called rb

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //associate the rigidbody component on the tank gameobject with the name rb
    }

    //need to learn about namespaces so I can make these internal
    public void ApplyMovement(float verticalInput)
    {
        Vector3 movement = transform.forward * verticalInput;
        rb.velocity = movement;
    }

    public void ApplyHullRotation(float horizontalInput)
    {
        transform.Rotate(0, horizontalInput, 0);
    }
}
