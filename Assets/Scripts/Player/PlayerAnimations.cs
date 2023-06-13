using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void SetMoveAnimation(bool isMoving)
    {
        _playerAnimator.SetBool("IsMoving", isMoving);
    }

    public void SetJumpingAnimation(bool isJumping)
    {
        _playerAnimator.SetBool("IsJumping", isJumping);
    }
}
