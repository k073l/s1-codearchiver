using System;

namespace ScheduleOne.Core.Equipping.Framework;
public interface IEquippablePlayerUser : IEquippableUser
{
    IFirstPersonReferencesProvider FirstPersonReferences { get; }

    bool ThirdPersonMeshesVisibleToLocalPlayer { get; }

    event Action<bool> OnThirdPersonMeshesVisibilityChanged;
    void SetThirdPersonMeshesVisibility(bool visible);
}