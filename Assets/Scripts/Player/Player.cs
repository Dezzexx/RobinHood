using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private Health _playerHealth;

    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _timeForReloading;

    private int _currentHealth;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        Events.OnPlayerTakeDamage.AddListener(DamageTaken);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnDestroy()
    {
        Events.OnPlayerTakeDamage.RemoveListener(DamageTaken);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _playerHealth.SetMaxHealth(_currentHealth);
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
        if (_playerInput.PlayerAction.Shoot.triggered) _playerWeapon.Shoot(_timeForReloading);
    }

    public Vector2 GetPlayerPositon()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    private void DamageTaken(int damage)
    {
        _currentHealth -= damage;
        _playerHealth.SetHealth(_currentHealth);
    }
}
