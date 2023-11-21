using UnityEngine;

namespace Mechanics
{
    public sealed class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        private Projectile projectilePrefab;

        public Projectile SpawnProjectile(Transform parent, Vector3 position)
        {
            return Instantiate(projectilePrefab, position, Quaternion.identity, parent);
        }
    }
}