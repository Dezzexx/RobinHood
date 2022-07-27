using UnityEngine;

public class PlayerWeapon : Bow
{
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _tensionForce;

    public override void Shoot(float timeForReload)
    {
        if (!_canShoot) return;

        var arrow = GameManager.Instance._arrowPlayerPooler.GetObject();
        arrow.transform.position = _shootPoint.position;
        arrow.transform.rotation = _shootPoint.rotation;
        
        arrow.SetActive(true);
        arrow.GetComponent<Rigidbody2D>().velocity = transform.right * _tensionForce;
        StartCoroutine(Reload(timeForReload));
    }
}
