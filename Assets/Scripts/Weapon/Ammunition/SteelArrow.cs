using System.Collections;
using UnityEngine;

public class SteelArrow : Arrow
{
    [SerializeField] int _damage;

    private void OnEnable()
    {
        StartCoroutine(DestroyArrow());
    }

    private IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance._arrowPlayerPooler.ReturnObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out EnemyAI enemy))
        {
            enemy.DamageTaken(_damage);
        }
    }
}
