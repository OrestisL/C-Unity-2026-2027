using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{
    private static readonly int IsGroundedHash = Animator.StringToHash(Constants.AnimatorParams.IS_GROUNDED);
    private static readonly int SpeedHash = Animator.StringToHash(Constants.AnimatorParams.SPEED);
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(SpeedHash, speed);
    }

    public void SetJumping(bool isJumping)
    {
        _animator.SetBool(IsGroundedHash, isJumping);
    }
}
