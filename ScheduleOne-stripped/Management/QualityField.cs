using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class QualityField : ConfigField
{
    public UnityEvent<EQuality> onValueChanged;
    public EQuality Value { get; protected set; } = EQuality.Standard;

    public QualityField(EntityConfiguration parentConfig);
    public void SetValue(EQuality value, bool network);
    public override bool IsValueDefault();
    public QualityFieldData GetData();
    public void Load(QualityFieldData data);
}