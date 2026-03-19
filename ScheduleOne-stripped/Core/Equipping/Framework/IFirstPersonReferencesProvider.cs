using UnityEngine;

namespace ScheduleOne.Core.Equipping.Framework;
public interface IFirstPersonReferencesProvider
{
    Transform EquipContainer { get; }
}