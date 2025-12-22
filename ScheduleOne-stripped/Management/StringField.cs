using ScheduleOne.Persistence.Datas;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class StringField : ConfigField
{
    private string _defaultValue;
    private bool _canBeNullOrEmpty;
    public UnityEvent<string> onItemChanged;
    public string Value { get; protected set; } = string.Empty;
    public int CharacterLimit { get; protected set; } = -1;

    public StringField(EntityConfiguration parentConfig, string defaultValue);
    public void SetValue(string value, bool network);
    public void Configure(int characterLimit, bool canBeNullOrEmpty);
    public override bool IsValueDefault();
    public StringFieldData GetData();
    public void Load(StringFieldData data);
}