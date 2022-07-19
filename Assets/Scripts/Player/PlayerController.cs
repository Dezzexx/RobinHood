using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private Bow _bow;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        Movement();
        PlayerShoot();
    }

    private void Movement()
    {
        Vector2 moveInput = _playerInput.PlayerAction.Move.ReadValue<Vector2>();
        transform.Translate(moveInput * _playerSpeed * Time.fixedDeltaTime);
    }

    private void PlayerShoot()
    {
        if (_playerInput.PlayerAction.Shoot.triggered) _bow.Shoot();
    }
}
