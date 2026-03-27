using UnityEngine;
using UnityEngine.InputSystem;

public class AngularVelocity : MonoBehaviour
{
    public float rotationSpeed = 5f; // ความเร็วการหมุน (rad/s)

    private Rigidbody rb;

    void Start()
    {
        // ดึง Rigidbody ของวัตถุ
        rb = GetComponent<Rigidbody>();

        // เริ่มต้นไม่หมุน
        rb.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        // ถ้ากดปุ่ม A → หมุนรอบแกน Y
        if (Keyboard.current.aKey.isPressed)
        {
            rb.angularVelocity = new Vector3(0f, rotationSpeed, 0f);
        }
        else
        {
            // ถ้าไม่มีปุ่มถูกกด → หยุดทันที
            rb.angularVelocity = Vector3.zero;
        }
    }
}