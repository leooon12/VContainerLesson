using App;
using VContainer.Unity;

namespace VContainer
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SaveManager>(Lifetime.Singleton);
            builder.Register<SceneController>(Lifetime.Singleton);
        }
    }
}