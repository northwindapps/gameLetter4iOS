using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Header("Joystick Settings")]
    public FixedJoystick movementJoystick; // Reference to the movement joystick
    public FixedJoystick lookJoystick;     // Reference to the look joystick

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Camera Settings")]
    public float lookSensitivity = 100f; // Sensitivity for the look joystick
    public Transform playerCamera;
    public float pitchMin = -90f;
    public float pitchMax = 90f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private float pitch = 0f; // Vertical camera angle

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    void Update()
    {
        HandleMovement();
        HandleLook();
    }

    void HandleMovement()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep the player grounded
        }

        // Get input from the movement joystick
        float moveX = movementJoystick.Horizontal; // Joystick horizontal input
        float moveZ = movementJoystick.Vertical;   // Joystick vertical input

        // Calculate movement direction relative to player orientation (local space)
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleLook()
    {
        // Get input from the look joystick
        float lookX = lookJoystick.Horizontal * lookSensitivity * Time.deltaTime;
        float lookY = lookJoystick.Vertical * lookSensitivity * Time.deltaTime;

        // Rotate the camera vertically (pitch)
        pitch -= lookY; // Invert Y-axis to simulate natural FPS look
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax); // Clamp the pitch to prevent over-rotation

        // Apply pitch to the camera
        playerCamera.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Rotate the player horizontally (yaw)
        transform.Rotate(Vector3.up, lookX); // Rotate the player around the Y-axis
    }

    // Optional: Implement Jump via a UI button or another input method
    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
