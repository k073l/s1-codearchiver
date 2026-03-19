using FishNet.Object;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Items.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
public interface INetworkedEquippableUser : IEquippableUser
{
    NetworkBehaviour NetworkBehaviour { get; }

    Transform ItemHandlerContainer => ((Component)NetworkBehaviour).transform;

    IEquippedItemHandler EquipLocal(EquippableData equippable);
    IEquippedItemHandler EquipLocal(BaseItemInstance item);
}