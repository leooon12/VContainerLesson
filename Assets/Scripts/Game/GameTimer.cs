using System;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class GameTimer : ITickable
    {
        public event Action<float> Ticked;
        
        [ShowInInspector, ReadOnly]
        public float CurrentTime { get; private set; }
        
        [ShowInInspector, ReadOnly]
        public bool IsSet { get; private set; }

        void ITickable.Tick()
        {
            if (IsSet)
            {
                CurrentTime += Time.deltaTime;
                Ticked?.Invoke(CurrentTime);
            }
        }

        public void StartTimer()
        {
            CurrentTime = 0f;
            IsSet = true;
        }

        public void StopTimer()
        {
            IsSet = false;
        }
    }
}