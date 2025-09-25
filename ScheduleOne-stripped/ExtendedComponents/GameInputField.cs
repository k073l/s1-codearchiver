using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.ExtendedComponents;
public class GameInputField : TMP_InputField
{
    protected override void Awake();
    private void EditStart(string newVal);
    private void EndEdit(string newVal);
}