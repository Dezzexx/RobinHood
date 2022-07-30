using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Animator _animator;
 
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _timeForReloading;
    [SerializeField] private bool _isAlive = true;

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
        if (_isAlive)
        {
            Movement();
            PlayerShoot();
        }
        Death();
    }

    private void Movement()
    {
        Vector2 moveInput = _playerInput.PlayerAction.Move.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            transform.Translate(moveInput * _playerSpeed * Time.fixedDeltaTime);
            _animator.SetBool("isWalkin", true);
        }
        else
        {
            _animator.SetBool("isWalkin", false);
        }
    }

    private void PlayerShoot()
    {
        if (_playerInput.PlayerAction.Shoot.triggered)
        {
            _playerWeapon.Shoot(_timeForReloading);
            _animator.SetBool("isAttack", true);
        }
        else _animator.SetBool("isAttack", false);
    }

    public Vector2 GetPlayerPositon()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    private void DamageTaken(int damage)
    {
        _currentHealth -= damage;
        _playerHealth.SetHealth(_currentHealth);
        StartCoroutine(HasHit());
    }

    private void Death()
    {
        if (_currentHealth <= 0)
        {
            _isAlive = false;
            _animator.SetBool("isDeath", true);
        }
    }

    private IEnumerator HasHit()
    {
        _animator.SetBool("hasHit", true);
        yield return new WaitForSecondsRealtime(0.5f);
        _animator.SetBool("hasHit", false);
    }
}
