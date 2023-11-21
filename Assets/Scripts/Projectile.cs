using UnityEngine;

public sealed class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float attackDistance = 1;

    [SerializeField]
    private float speed = 8;

    private Player _player;

    private void Awake()
    {
        _player = Player.Instance;
    }

    private void Update()
    {
        if (_player == null)
        {
            Destroy(gameObject);
            return;
        }

        var direction = _player.transform.position - transform.position;

        if (direction.magnitude <= attackDistance)
        {
            _player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            transform.LookAt(_player.transform.position);

            var movement = speed * Time.deltaTime * direction.normalized;
            transform.position += movement;
        }
    }
}