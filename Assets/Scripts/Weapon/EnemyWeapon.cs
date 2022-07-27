using UnityEditor;
using UnityEngine;

public class EnemyWeapon : Bow
{
    [SerializeField] private EnemyArrow _enemyArrow;
    [SerializeField] private Transform _shootPoint;
    
    [SerializeField] private float _tensionForce;

    public override void Shoot(float timeForReload)
    {
        if (!_canShoot) return;

        var arrow = Instantiate(_enemyArrow, _shootPoint.position, _shootPoint.rotation);
        arrow.GetComponent<Rigidbody2D>().velocity = transform.right * _tensionForce;
        StartCoroutine(Reload(timeForReload));
    }
}
