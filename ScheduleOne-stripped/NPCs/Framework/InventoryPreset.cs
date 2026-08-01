using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Inventory Preset")]
public class InventoryPreset : ValueProviderScriptableObject<Inventory>
{
    public Inventory value;
    public override Inventory GetValue();
}