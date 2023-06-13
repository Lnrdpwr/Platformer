using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //Скрипт отвечает за анимации
    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();//Получаем аниматор игрока
    }

    public void SetMoveAnimation(bool isMoving)
    {
        _playerAnimator.SetBool("IsMoving", isMoving);//Изменяем значение, управляющее анимацией ходьбы(если истина - игрок идёт, если ложь - стоит)
    }

    public void SetJumpingAnimation(bool isJumping)
    {
        _playerAnimator.SetBool("IsJumping", isJumping);//Изменяем значение, управляющее анимацией прыжка(истина - игрок прыгает, ложь - нет)
    }
}

/*В окне аниматора(windows -> animations -> animator) есть все анимации, переходы и значения,
которые влияют на переход анимаций
 */
