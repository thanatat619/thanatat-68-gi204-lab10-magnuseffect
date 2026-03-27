using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagnusSoccerKick : MonoBehaviour
{
    public float kickForce = 20f;
    public float spinForce = 10f;
    public float magnusStrength = 5f;
    public float spinDamping = 0.98f;

    private Rigidbody rb;
    private Vector3 spin; // เก็บค่า spin ของลูกบอล

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KickBall();
        }
    }

    void FixedUpdate()
    {
        ApplyMagnusEffect();
        ApplySpinDamping();
    }

    void KickBall()
    {
        // ยิงลูกไปข้างหน้า
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(transform.forward * kickForce, ForceMode.Impulse);

        // ใส่ spin (หมุนรอบแกน Y เพื่อให้โค้งซ้าย/ขวา)
        spin = Vector3.up * spinForce;

        rb.angularVelocity = spin;
    }

    void ApplyMagnusEffect()
    {
        // Magnus Force = Spin x Velocity
        Vector3 magnusForce = Vector3.Cross(spin, rb.linearVelocity) * magnusStrength;

        rb.AddForce(magnusForce);
    }

    void ApplySpinDamping()
    {
        // ลด spin ทีละนิด (ให้สมจริง)
        spin *= spinDamping;
        rb.angularVelocity = spin;
    }
}