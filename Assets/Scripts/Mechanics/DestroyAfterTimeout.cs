using UnityEngine;

namespace Mechanics
{
    public class DestroyAfterTimeout : MonoBehaviour
    {
        [SerializeField]
        private float timeout = 3f;

        private float _time = 0;

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= timeout)
            {
                Destroy(gameObject);
            }
        }
    }
}
