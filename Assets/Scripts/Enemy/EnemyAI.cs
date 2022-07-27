using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private Health _enemyHealth;


    [SerializeField] private float _attackRange;
    [SerializeField] private float _timeForReloading;
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private void Awake()
    {
        Events.OnEnemyTakeDamage.AddListener(DamageTaken);
    }

    private void OnDestroy()
    {
        Events.OnEnemyTakeDamage.RemoveListener(DamageTaken);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _enemyHealth.SetMaxHealth(_currentHealth);
    }

    private void FixedUpdate()
    {
        EnemyShoot();
    }

    private void EnemyShoot()
    {
        Vector2 currentPosition = transform.position;

        if (Vector2.Distance(currentPosition, GameManager.Instance.player.GetPlayerPositon()) < _attackRange) _enemyWeapon.Shoot(_timeForReloading);
    }

    private void DamageTaken(int damage)
    {
        _currentHealth -= damage;
        _enemyHealth.SetHealth(_currentHealth);

        if (_currentHealth <= 0) Death();
    }

    private void Death()
    {
        GlobalEvents.SendEnemyKilled();
        Destroy(gameObject);
    }
}
