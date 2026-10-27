using UnityEngine;
using UnityEngine.InputSystem;
using Constants;
using System;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public float WalkSpeed;
    public float RunSpeed;
    public float JumpHeight;
    public float Gravity = 10;
    private bool _running;

    private InputAction _moveAction;
    private InputAction _runAction;
    
    [SerializeField]
    private Camera _mainCam;

    private Vector3 _velocity;
    private float turnSmoothVelocity, turnSmoothTime = 0.1f;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();

        _moveAction = InputSystem.actions.FindAction(InputNames.MOVE);

        _runAction = InputSystem.actions.FindAction(InputNames.RUN);
        _runAction.started += ToggleRun;
        _runAction.canceled += ToggleRun;

        _mainCam = Camera.main;

        InputSystem.actions.FindAction(InputNames.JUMP).started += Jump;
    }

    private void ToggleRun(InputAction.CallbackContext context)
    {
        _running = context.started == true;
    }

    private void Update()
    {
        Vector2 move = _moveAction.ReadValue<Vector2>();
        Move(move);

        ApplyGravity();
    }

    private void Move(Vector2 input)
    {
        if (input.sqrMagnitude <= 0.1f)
        {
            return;
        }

        Vector3 inputDirection = new Vector3(input.x, 0, input.y).normalized;

        //rotate player to where the camera is looking
        float targetAngle = _mainCam.transform.eulerAngles.y + Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.localRotation = Quaternion.Euler(0, angle, 0);

        float currentSpeed = _running ? RunSpeed : WalkSpeed;
        //rotate forward to look direction
        Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward * currentSpeed;

        Controller.Move(Time.deltaTime * moveDirection);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (!Controller.isGrounded) return;

        _velocity.y = Mathf.Sqrt(2 * Mathf.Abs(Gravity) * JumpHeight);
    }
    private void ApplyGravity()
    {
        Controller.Move(_velocity * Time.deltaTime);

        if (Controller.isGrounded && _velocity.y < 0)
            _velocity.y = Gravity;
        else if (!Controller.isGrounded)
            _velocity.y -= Mathf.Abs(Gravity) * Time.deltaTime;
    }

    private void OnDisable()
    {
        InputSystem.actions.FindAction("Jump").started -= Jump;
        _runAction.started -= ToggleRun;
        _runAction.canceled -= ToggleRun;
    }
}
