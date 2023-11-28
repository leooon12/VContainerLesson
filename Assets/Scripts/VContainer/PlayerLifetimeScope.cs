using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public sealed class PlayerLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<Player>();
            builder.RegisterComponentInHierarchy<CharacterController>();
        }
    }
}