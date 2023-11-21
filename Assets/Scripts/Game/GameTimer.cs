using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-100)]
    public sealed class GameTimer : MonoBehaviour
    {
        public static GameTimer Instance { get; private set; }

        public event Action<float> Ticked;
        
        [ShowInInspector, ReadOnly]
        public float CurrentTime { get; private set; }
        
        [ShowInInspector, ReadOnly]
        public bool IsSet { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Update()
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