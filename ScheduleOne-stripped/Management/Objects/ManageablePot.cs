using ScheduleOne.Management.Presets;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.Management.Objects;
[RequireComponent(typeof(Pot))]
public class ManageablePot : ManageableObject
{
    public PotPreset CurrentPreset;
    protected virtual void Awake();
    public override ManageableObjectType GetObjectType();
    public override Preset GetCurrentPreset();
    protected override void SetPreset_Internal(Preset newPreset);
}