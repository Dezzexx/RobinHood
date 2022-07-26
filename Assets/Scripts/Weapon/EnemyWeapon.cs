using UnityEngine;

public class EnemyWeapon : Bow
{
    public override void Shoot()
    {
        base.Shoot();
        Reload(3f);
    }
}
