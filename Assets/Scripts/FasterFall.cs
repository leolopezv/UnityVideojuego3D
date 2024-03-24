using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterFall : MonoBehaviour
{
    public float fallForce; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
                rb.isKinematic = false;

    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * fallForce, ForceMode.Force);
    }
}
