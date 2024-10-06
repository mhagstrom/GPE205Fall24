using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    
    public abstract void ApplyMovement(float verticalInput);
    
    public abstract void ApplyHullRotation(float horizontalInput);
}
