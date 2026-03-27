using UnityEngine;
using UnityEngine.InputSystem;

public class TorqueRotate : MonoBehaviour
{
    public float torqueForce = 10f; // ความแรงของแรงบิด

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ถ้ากดปุ่ม D → หมุนรอบแกน Z
        if (Keyboard.current.dKey.isPressed)
        {
            // ใช้ AddTorque หมุนรอบแกน Z
            rb.AddTorque(new Vector3(0f, 0f, torqueForce));
        }
    }
}