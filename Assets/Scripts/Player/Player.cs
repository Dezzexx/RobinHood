using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private PlayerWeapon _playerWeapon;

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
        if (_playerInput.PlayerAction.Shoot.triggered) _playerWeapon.Shoot(1);
    }

    public Vector2 GetPlayerPositon()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
