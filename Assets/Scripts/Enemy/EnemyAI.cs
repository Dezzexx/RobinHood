using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private Animator _animator;


    [SerializeField] private float _attackRange;
    [SerializeField] private float _timeForReloading;
    [SerializeField] private int _maxHealth;
    [SerializeField] private bool _isAlive = true;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _enemyHealth.SetMaxHealth(_currentHealth);
    }

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            EnemyShoot();
        }
    }

    public void DamageTaken(int damage)
    {
        _currentHealth -= damage;
        _enemyHealth.SetHealth(_currentHealth);
        StartCoroutine(HasHit());

        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    private void EnemyShoot()
    {
        Vector2 currentPosition = transform.position;
        var currentPlayerPosition = GameManager.Instance.player.GetPlayerPositon();
        var gameOver = GameManager.Instance.GameOverFlag;

        if ((Vector2.Distance(currentPosition, currentPlayerPosition) < _attackRange) && !gameOver)
        {
            _enemyWeapon.Shoot(_timeForReloading);
            _animator.SetBool("isAttack", true);
        }
        else _animator.SetBool("isAttack", false);
    }

    private void Death()
    {
        _isAlive = false;
        GlobalEvents.SendEnemyKilled();
        Destroy(gameObject);
    }

    private IEnumerator HasHit()
    {
        _animator.SetBool("hasHit", true);
        yield return new WaitForSecondsRealtime(0.5f);
        _animator.SetBool("hasHit", false);
    }
}
