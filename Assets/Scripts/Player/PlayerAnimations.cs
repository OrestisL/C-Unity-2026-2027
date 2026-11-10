using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{
    private static readonly int IsGroundedHash = Animator.StringToHash(Constants.AnimatorParams.IS_GROUNDED);
    private static readonly int SpeedHash = Animator.StringToHash(Constants.AnimatorParams.SPEED);
    private static readonly int KickHash = Animator.StringToHash(Constants.AnimatorParams.KICK);
    private static readonly int PunchHash = Animator.StringToHash(Constants.AnimatorParams.PUNCH);

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

    public void Kick()
    {
        _animator.SetTrigger(KickHash);   
    }

      public void Punch()
    {
        _animator.SetTrigger(PunchHash);   
    }
}
