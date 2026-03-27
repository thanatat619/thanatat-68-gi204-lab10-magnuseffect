using UnityEngine;

public class AngularVelocity : MonoBehaviour
{
    public float rotationSpeed = 5f; // rad/s

    private Rigidbody rb;
    private bool isStopped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isStopped)
        {
            // หมุนตลอดเวลา
            rb.angularVelocity = new Vector3(0f, rotationSpeed, 0f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isStopped = !isStopped;
        }
    }
}