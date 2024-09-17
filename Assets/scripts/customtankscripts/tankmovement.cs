using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class tankmovement : MonoBehaviour
{
    private Rigidbody rb;

    //if it has no reason to be public set it to private, if you still need it exposed in the inspector set it as a serializefield private so only this script can use it, but its values are still editable in unity
    [Header("Movement Data")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;

    [Header("Aim Data")]
    [SerializeField] private LayerMask whatIsAimMask;
    [SerializeField] private GameObject aimSphere;
    
    [Header("Turret Data")]
    [SerializeField] private GameObject tankturret;
    [SerializeField] private float turretRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAim();
        CheckInputs();
    }

    private void CheckInputs()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput < 0)
            horizontalInput = -Input.GetAxis("Horizontal");
    }

    //Timestamp of update rate found in project settings of unity > time
    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyHullRotation();
        ApplyTurretRotation();
    }

    private void ApplyTurretRotation()
    {
        Vector3 direction = aimSphere.transform.position - tankturret.transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        tankturret.transform.rotation = Quaternion.RotateTowards(tankturret.transform.rotation, targetRotation, turretRotationSpeed);

        //tankturret.LookAt(aimSphere);
    }

    private void ApplyHullRotation()
    {
        transform.Rotate(0, horizontalInput * rotationSpeed, 0);
    }

    private void ApplyMovement()
    {
        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        rb.velocity = movement;
    }

    private void UpdateAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, whatIsAimMask))
        {
            aimSphere.transform.position = hit.point;
        }

        
    }
}
