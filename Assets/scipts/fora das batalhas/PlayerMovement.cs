using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float rotationSpeed = 10f;

    [Header("Pulo")]
    public float jumpHeight = 2f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;

    private bool isGrounded;

    [HideInInspector]
    public bool canMove = true;

    private Vector2 moveInput;
    private bool jumpPressed;
    private bool runPressed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!canMove)
            return;

        GetInput();
        Move();
    }

    void GetInput()
    {
        Keyboard keyboard = Keyboard.current;

        moveInput = Vector2.zero;

        if (keyboard.wKey.isPressed)
            moveInput.y += 1;

        if (keyboard.sKey.isPressed)
            moveInput.y -= 1;

        if (keyboard.aKey.isPressed)
            moveInput.x -= 1;

        if (keyboard.dKey.isPressed)
            moveInput.x += 1;

        jumpPressed = keyboard.spaceKey.wasPressedThisFrame;

        runPressed = keyboard.leftShiftKey.isPressed;
    }

    void Move()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move =
            new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        if (move.magnitude >= 0.1f)
        {
            Camera cam = Camera.main;

            Vector3 camForward = cam.transform.forward;
            Vector3 camRight = cam.transform.right;

            camForward.y = 0;
            camRight.y = 0;

            Vector3 direction =
                (camForward * move.z + camRight * move.x).normalized;

            float currentSpeed =
                runPressed ? runSpeed : walkSpeed;

            controller.Move(
                direction * currentSpeed * Time.deltaTime
            );

            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        if (jumpPressed && isGrounded)
        {
            velocity.y =
                Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}