using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Arrow : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Pooler _pool;
    private bool _hasHit = false;

    private void OnEnable()
    {
        StartCoroutine(DestroyArrow());
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _pool = transform.parent.GetComponent<Pooler>();
    }

    protected abstract void DamageDealing();

    private IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(3f);
        _rb.isKinematic = false;
        _pool.ReturnObject(gameObject);
    }

    private void FixedUpdate()
    {
        ArrowFall();
    }

    //check
    protected void ArrowFall()
    {
        if (_hasHit == false)
        {
            float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _hasHit = true;
        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;
    }
}
