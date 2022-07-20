using UnityEngine;

public class EnemyWeapon : Bow
{
    public override void Shoot(int direction)
    {
        base.Shoot(direction);
        Reload(3f);
    }
}
