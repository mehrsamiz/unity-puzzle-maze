using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 180f; // degrees per second

    private Rigidbody rb;
    private Vector2 moveInput;
    private float yaw;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Recommended for a player capsule/cube controller
        rb.freezeRotation = true;

        yaw = transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Movement input (WASD / Arrow keys)
        float x = Input.GetAxisRaw("Horizontal"); // A/D
        float z = Input.GetAxisRaw("Vertical");   // W/S
        moveInput = new Vector2(x, z);
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);

        // Mouse yaw rotation
        float mouseX = Input.GetAxis("Mouse X");
        yaw += mouseX * mouseSensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    private void FixedUpdate()
    {
        // Move relative to facing direction, only on X/Z
        Vector3 dir = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized;
        Vector3 targetVelocity = new Vector3(dir.x * moveSpeed, rb.linearVelocity.y, dir.z * moveSpeed);

        // Unity 2022/2023 uses rb.velocity; if your API shows velocity, use that.
        // Some newer versions expose linearVelocity; keep the one that compiles for you:
        rb.linearVelocity = targetVelocity;
    }
}