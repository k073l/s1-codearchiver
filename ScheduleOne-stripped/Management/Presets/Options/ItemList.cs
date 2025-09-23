using System.Collections.Generic;

namespace ScheduleOne.Management.Presets.Options;
public class ItemList : Option
{
    public bool All;
    public bool None;
    public List<string> Selection;
    public bool CanBeAll { get; protected set; } = true;
    public bool CanBeNone { get; protected set; } = true;
    public List<string> OptionList { get; protected set; } = new List<string>();

    public ItemList(string name, List<string> optionList, bool canBeAll, bool canBeNone);
    public override void CopyTo(Option other);
    public override string GetDisplayString();
}