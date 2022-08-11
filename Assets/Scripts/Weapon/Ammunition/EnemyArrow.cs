using System.Collections;
using UnityEngine;

public class EnemyArrow : Arrow
{
    [SerializeField] int _damage;

    private void OnEnable()
    {
        StartCoroutine(DestroyArrow());
    }

    private IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Events.SendPlayerTakeDamage(_damage);
        }
    }
}
