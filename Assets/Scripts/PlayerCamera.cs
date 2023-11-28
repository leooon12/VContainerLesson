using Game;
using UnityEngine;

public sealed class PlayerCamera : MonoBehaviour, IInitializeGameListener, IStartGameListener, IFinishGameListener
{
    [SerializeField]
    private Vector3 offset;
    
    private Player _player;
    
    private void Awake()
    {
        _player = Player.Instance;
    }

    private void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = _player.transform.position + offset;
        }
    }

    void IInitializeGameListener.OnGameInitialized()
    {
        enabled = false;
    }

    void IStartGameListener.OnGameStarted()
    {
        enabled = true;
    }

    void IFinishGameListener.OnGameFinished()
    {
        enabled = false;
    }
}