using System.Collections;
using Game;
using Mechanics;
using UnityEngine;

public sealed class Tower : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private float minShootTimeout = 0.5f;

    [SerializeField]
    private float maxShootTimeout = 1.5f;

    private ProjectileSpawner _projectileSpawner;

    private Coroutine _attackCoroutine;

    private void Awake()
    {
        _projectileSpawner = GetComponentInChildren<ProjectileSpawner>();
    }

    void IStartGameListener.OnGameStarted()
    {
        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    void IFinishGameListener.OnGameFinished()
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

            _projectileSpawner.SpawnProjectile(transform, shootPoint.position);
        }
        
        // ReSharper disable once IteratorNeverReturns
    }
}