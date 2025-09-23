using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;

namespace ScheduleOne.ObjectScripts;
public class Meth_Equippable : Equippable_Viewmodel
{
    public MethVisuals Visuals;
    public override void Equip(ItemInstance item);
}