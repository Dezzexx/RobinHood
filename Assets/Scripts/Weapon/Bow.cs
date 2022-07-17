using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour
{
    [SerializeField] private float _tensionForce;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Pooler _arrowPool;

    private bool _canShoot = true;

    public void Shoot()
    {
        if (!_canShoot) return;

        GameObject arrow = _arrowPool.GetObject();
        arrow.transform.position = _shootPoint.position;
        arrow.transform.rotation = _shootPoint.rotation;

        arrow.SetActive(true);
        arrow.GetComponent<Rigidbody2D>().velocity = transform.right * _tensionForce;
        StartCoroutine(Reload());
    }

    /// <summary>
    /// Timer for Reload.
    /// </summary>
    private IEnumerator Reload()
    {
        _canShoot = false;
        yield return new WaitForSeconds(0.5f);
        _canShoot = true;
    }
}
