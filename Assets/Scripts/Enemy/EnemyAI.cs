using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private Player _player;

    private void FixedUpdate()
    {
        EnemyShoot();
    }

    private void EnemyShoot()
    {
        Vector2 currentPosition = transform.position;
        float attackRange = 3f;

        if (Vector2.Distance(currentPosition, _player.GetPlayerPositon()) < attackRange) _enemyWeapon.Shoot();
    }
}
