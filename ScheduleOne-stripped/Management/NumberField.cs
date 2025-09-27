using ScheduleOne.Persistence.Datas;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class NumberField : ConfigField
{
    public UnityEvent<float> onItemChanged;
    public float Value { get; protected set; }
    public float MinValue { get; protected set; }
    public float MaxValue { get; protected set; } = 100f;
    public bool WholeNumbers { get; protected set; }

    public NumberField(EntityConfiguration parentConfig);
    public void SetValue(float value, bool network);
    public void Configure(float minValue, float maxValue, bool wholeNumbers);
    public override bool IsValueDefault();
    public NumberFieldData GetData();
    public void Load(NumberFieldData data);
}