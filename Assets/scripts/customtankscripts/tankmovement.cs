using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmovement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movement Data")]
    public float moveSpeed;
    public float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput < 0)
            horizontalInput = -Input.GetAxis("Horizontal");
    }

    //Timestamp of update rate found in project settings of unity > time
    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        rb.velocity = movement;

        transform.Rotate(0, horizontalInput * rotationSpeed, 0);
    }
}
