using Game;
using Rules;
using UI;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class SceneLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Player playerPrefab;
        
        [SerializeField]
        private Projectile projectilePrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManager>().As<IGameManager>();
            builder.RegisterEntryPoint<GameTimer>().AsSelf();

            builder.RegisterFactory<Transform, Vector3, Projectile>(objectResolver =>
            {
                return (parent, position) =>
                    objectResolver.Instantiate(projectilePrefab, position, Quaternion.identity, parent);
            }, Lifetime.Singleton);

            builder.Register(_ =>
            {
                using (EnqueueParent(this))
                {
                    return Instantiate(playerPrefab);
                }
            }, Lifetime.Singleton);
            
            builder.RegisterComponentInHierarchy<GameOverScreen>();

            ConfigureGameListeners(builder);
        }

        private void ConfigureGameListeners(IContainerBuilder builder)
        {
            builder.Register<GameOverScreenController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameTimerController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerDeathObserver>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SaveController>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterComponentInHierarchy<GameTimerAdapter>().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<PlayerHealthAdapter>().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<TowerController>().AsImplementedInterfaces();
        }
    }
}
