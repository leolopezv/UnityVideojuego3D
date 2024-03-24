using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public float acceleration = 15f;
    public float steeringSpeed = 2f;
    public float maxTurnAngle = 30f;
    public float topSpeed = 100f;

    private Rigidbody rb;
    private float currentSpeed;
    public float turnAngle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        if (rb.velocity.sqrMagnitude < topSpeed * topSpeed)
        {
            currentSpeed = acceleration * moveInput;
            rb.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
        }

        turnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        if (rb.velocity.magnitude > 1) 
        {
            transform.Rotate(0, turnAngle * steeringSpeed * Time.fixedDeltaTime, 0);
        }
    }

  
}
