using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Items.Framework;
public abstract class BaseItemDefinition : ScriptableObject
{
    private const int DefaultStackLimit;
    [Header("General")]
    public string Name;
    public string ID;
    [TextArea(3, 10)]
    public string Description;
    public Sprite Icon;
    [Header("Inventory")]
    public EItemCategory Category;
    public int StackLimit;
    public bool UsableInFilters;
    [Header("Equipping")]
    public EquippableData EquippableData;
    [Header("Legal Status")]
    public ELegalStatus legalStatus;
    public virtual void ValidateDefinition();
}