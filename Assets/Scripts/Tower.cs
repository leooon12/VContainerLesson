using System;
using System.Collections;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

public sealed class Tower : MonoBehaviour
{
    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private float minShootTimeout = 0.5f;

    [SerializeField]
    private float maxShootTimeout = 1.5f;

    private Func<Transform, Vector3, Projectile> _projectileFactory;
    
    private Coroutine _attackCoroutine;

    [Inject]
    private void Construct(Func<Transform, Vector3, Projectile> projectileFactory)
    {
        _projectileFactory = projectileFactory;
    }

    public void StartShooting()
    {
        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    public void StopShooting()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }
    
    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            var timeout = Random.Range(minShootTimeout, maxShootTimeout);
            yield return new WaitForSeconds(timeout);

            _projectileFactory.Invoke(transform, shootPoint.position);
        }
        
        // ReSharper disable once IteratorNeverReturns
    }
}