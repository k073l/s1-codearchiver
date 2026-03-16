using ScheduleOne.Core.Items.Framework;

namespace ScheduleOne.Core.Equipping.Framework;
public interface IEquippableUser
{
    IThirdPersonReferencesProvider ThirdPersonReferences { get; }

    bool IsLocalPlayer { get; }

    IEquippedItemHandler Equip(EquippableData equippable);
    IEquippedItemHandler Equip(BaseItemInstance item);
    void Unequip(IEquippedItemHandler equippedItem);
    void UnequipAll();
}