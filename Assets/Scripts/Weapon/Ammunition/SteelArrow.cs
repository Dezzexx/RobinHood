using UnityEngine;

public class SteelArrow : Arrow
{
    protected override void DamageDealing(int damage)
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GlobalEventManager.SendEnemyKilled();
            Destroy(other.gameObject);
        }
    }
}
