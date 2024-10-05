using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//Can't mess this up, will create a rigidbody if none is present and prevents removal of rigidbody from game object
public class TankMovement : MonoBehaviour
{
    private Rigidbody rb;
    //store the rigidbody as a variable called rb

    //if it has no reason to be public set it to private, if you still need it exposed in the inspector set it as a serializefield private so only this script can use it, but its values are still editable in unity
    [Header("Movement Data")]
    //Header draws a nice header in the inspector
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //associate the rigidbody component on the tank gameobject with the name rb
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyHullRotation();
    }

    private void ApplyMovement()
    {
        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        rb.velocity = movement;
    }

    private void ApplyHullRotation()
    {
        transform.Rotate(0, horizontalInput * rotationSpeed, 0);
    }
}
