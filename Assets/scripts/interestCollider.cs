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
}
