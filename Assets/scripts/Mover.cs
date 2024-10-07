using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{ 
    public abstract void ApplyMovement(float verticalInput);
    
    public abstract void ApplyHullRotation(float horizontalInput);
}
