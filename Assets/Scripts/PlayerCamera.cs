using Game;
using UnityEngine;
using VContainer;

public sealed class PlayerCamera : MonoBehaviour, IInitializeGameListener, IStartGameListener, IFinishGameListener
{
    [SerializeField]
    private Vector3 offset;
    
    private Player _player;
    
    [Inject]
    private void Construct(Player player)
    {
        _player = player;
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