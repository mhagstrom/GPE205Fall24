using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class interestCollider : MonoBehaviour
{
    [SerializeField] private AIController aiController;
    private void Awake()
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            aiController.SetTarget(other.transform);
        }
    }

    //for now this works to untarget the player when they leave the collider but later I will need to use an array/List/queue or maybe a hashmap for dynamic target prioritization to track multiple targets in and out with a RemoveTarget() on the aicontroller
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            aiController.SetTarget(null);
        }
    }
}
