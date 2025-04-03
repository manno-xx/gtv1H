using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 100f;
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0f, 2f, -4f); // 1st person (0,0,0), 3rd person (0,2,-4)

    private float xRotation = 0f;

    [Header("Movement Settings")]
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent unwanted physics rotation
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor for better control
    }
    
    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        UpdateCameraPosition();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents flipping

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);
    }

    void UpdateCameraPosition()
    {
        cameraTransform.position = transform.position + transform.TransformDirection(cameraOffset);
    }
}