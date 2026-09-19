using FishNet.Object;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Items.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
public interface INetworkedEquippableUser : IEquippableUser
{
    NetworkBehaviour NetworkBehaviour { get; }

    Transform ItemHandlerContainer => ((Component)NetworkBehaviour).transform;

    IEquippedItemHandler Equip_Networked(EquippableData equippable);
    IEquippedItemHandler Equip_Networked(BaseItemInstance item);
}