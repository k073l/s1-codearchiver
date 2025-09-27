using ScheduleOne.AvatarFramework.Customization;
using ScheduleOne.Clothing;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.UI.CharacterCreator;
public class CharacterCreatorField<T> : BaseCharacterCreatorField
{
    protected ClothingDefinition selectedClothingDefinition;
    public T value { get; protected set; }

    public virtual T ReadValue();
    public override void WriteValue(bool applyValue = true);
    public override void ApplyValue();
}