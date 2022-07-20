using UnityEngine;
using System.Collections;

public abstract class Bow : MonoBehaviour
{
    [SerializeField] protected private float _tensionForce;
    [SerializeField] protected private Transform _shootPoint;
    [SerializeField] protected private Pooler _arrowPool;

    protected bool _canShoot = true;


    /// <summary>
    /// direction - direction for shooting
    /// "1" - transform.right
    /// "-1" - transform.left.
    /// </summary>
    /// <param name="direction"></param>
    public virtual void Shoot(int direction)
    {
        if (!_canShoot) return;

        GameObject arrow = _arrowPool.GetObject();
        arrow.transform.position = _shootPoint.position;
        arrow.transform.rotation = _shootPoint.rotation;
        
        transform.right *= direction;
        arrow.SetActive(true);
        arrow.GetComponent<Rigidbody2D>().velocity = transform.right * _tensionForce;
        StartCoroutine(Reload(1f));
    }

    /// <summary>
    /// Timer for Reload.
    /// </summary>
    protected private IEnumerator Reload(float timeInSeconds)
    {
        _canShoot = false;
        yield return new WaitForSeconds(timeInSeconds);
        _canShoot = true;
    }
}
