using Game;
using UnityEngine;

public sealed class TowerController : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    private Tower[] _towers;

    private void Awake()
    {
        _towers = GetComponentsInChildren<Tower>();
    }

    void IStartGameListener.OnGameStarted()
    {
        foreach (var tower in _towers)
        {
            tower.StartShooting();
        }
    }

    void IFinishGameListener.OnGameFinished()
    {
        foreach (var tower in _towers)
        {
            tower.StopShooting();
        }
    }
}