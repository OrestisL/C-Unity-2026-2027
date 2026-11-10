using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerAnimations))]
public class PlayerAttacks : MonoBehaviour
{
    private PlayerAnimations _playerAnimations;
    private InputAction _leftClickAction;
    private InputAction _rightClickAction;

    public float KickCooldown = 5.0f;
    public float PunchCooldown = 5.0f;
    private float _kickCooldownTimer = 0.0f;
    private float _punchCooldownTimer = 0.0f;

    public CooldownIcon KickCooldownIcon;
    public CooldownIcon PunchCooldownIcon;
    private void Awake()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
        _leftClickAction = InputSystem.actions.FindAction(Constants.InputNames.LEFT_CLICK);
        _rightClickAction = InputSystem.actions.FindAction(Constants.InputNames.RIGHT_CLICK);

        _kickCooldownTimer = KickCooldown;
        _punchCooldownTimer = PunchCooldown;
    }

    private void OnEnable()
    {
        _leftClickAction.performed += Punch;
        _rightClickAction.performed += Kick;       
    }
    
    private void Punch(InputAction.CallbackContext context)
    {
        if (PunchCooldown > 0.0f)
            return;

        _playerAnimations.Punch();
        PunchCooldown = _punchCooldownTimer;
    }

    private void Kick(InputAction.CallbackContext context)
    {
        if (KickCooldown > 0.0f)
            return;

        _playerAnimations.Kick();
        KickCooldown = _kickCooldownTimer;
    }

    void Update()
    {
        if (KickCooldown > 0.0f)
        {
            KickCooldown -= Time.deltaTime;
            KickCooldownIcon.UpdateCooldown(KickCooldown / _kickCooldownTimer);
        }
        else
            KickCooldown = 0.0f;

        if(PunchCooldown > 0.0f)
        {
            PunchCooldown -= Time.deltaTime;
            PunchCooldownIcon.UpdateCooldown(PunchCooldown / _punchCooldownTimer);
        }
        else
            PunchCooldown = 0.0f;
    }

    private void OnDisable()
    {
        _leftClickAction.performed -= Punch;
        _rightClickAction.performed -= Kick;
    }
}
