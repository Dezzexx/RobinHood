using UnityEngine;
using System.Collections;

public abstract class Bow : MonoBehaviour
{
    protected bool _canShoot = true;

    public abstract void Shoot(float timeForReload);

    /// <summary>
    /// Timer for Reload.
    /// </summary>
    public virtual IEnumerator Reload(float timeInSeconds)
    {
        _canShoot = false;
        yield return new WaitForSecondsRealtime(timeInSeconds);
        _canShoot = true;
    }
}
