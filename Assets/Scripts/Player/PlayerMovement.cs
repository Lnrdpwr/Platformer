using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Параметры передвижения")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _yUnderline;

    private Rigidbody2D _rigidbody;
    private PlayerAnimations _playerAnimations;
    private SpriteRenderer _playerRenderer;
    private PlayerHealth _playerHealth;
    private float _horizontalMovement;
    private bool _onGround = true;
    private bool _lookingRight = true;

    private void Start()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerRenderer = GetComponent<SpriteRenderer>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        //Передвижение
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(_horizontalMovement * _speed, _rigidbody.velocity.y);

        //Поворот пероснажа вправо или влево
        if (_horizontalMovement < 0 && _lookingRight)
        {
            _playerRenderer.flipX = true;
            _lookingRight = false;
        }
        else if (_horizontalMovement > 0 && !_lookingRight)
        {
            _playerRenderer.flipX = false;
            _lookingRight = true;
        }
    }

    private void Update()
    {
        //Прыжок
        _onGround = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _groundLayer);//Проверяем, есть ли под ногами земля(создаём круг и проверяем, попадает ли в него платформа)
        if (_onGround && Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce(new Vector2(0, _jumpForce));

        //Проверка анимаций
        if (_horizontalMovement != 0)
            _playerAnimations.SetMoveAnimation(true);
        else
            _playerAnimations.SetMoveAnimation(false);

        if (!_onGround)
            _playerAnimations.SetJumpingAnimation(true);
        else
            _playerAnimations.SetJumpingAnimation(false);

        //Проверка, не упал ли игрок
        if (transform.position.y <= _yUnderline)
            _playerHealth.StopGame();
    }
}
