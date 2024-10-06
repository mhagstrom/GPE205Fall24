using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Aim Data")]
    [SerializeField] private LayerMask whatIsAimMask;
    [SerializeField] private AimCursor aimCursor; //reference to the aim cursor script without referencing the entire gameobject
    
    [Header("Turret Data")]
    [SerializeField] private Transform tankturret;
    [SerializeField] private Transform gunTube;
    [SerializeField] private float turretRotationSpeed;

    private void Update()
    {
        ApplyTurretRotation();
    }

    private void ApplyTurretRotation()
    {
        //rotate the tankTurret block around the Y axis to face the cursor with a speed delay
        //rotate the guntube at a pivot point around the local X  axis to face the cursor with a speed delay
        
        //if the angle between the turret and the cursor is less than 0.1f return
        Vector3 aimDirection = aimCursor.transform.position - tankturret.position;
        float angle = Vector3.Angle(tankturret.forward, aimDirection);
        if (angle < 0.1f)
        {
            //aimCursor is a variable but the type of that variable is a class so class.function applies here
            aimCursor.ShowTargetLock(true);
            return;
        }
        else
        {
            aimCursor.ShowTargetLock(false);
        }
        
        //rotate the turret on the Y axis to face the aimCursor
        Quaternion turretRotation = Quaternion.LookRotation(aimDirection, Vector3.up);
        tankturret.rotation = Quaternion.Slerp(tankturret.rotation, turretRotation, turretRotationSpeed * Time.deltaTime);
        
        //rotate the guntube on the local X axis to face the aimCursor
        Quaternion gunTubeRotation = Quaternion.LookRotation(aimDirection, tankturret.right);
        gunTube.localRotation = Quaternion.RotateTowards(gunTube.localRotation, gunTubeRotation, turretRotationSpeed * Time.deltaTime);
    }
}
