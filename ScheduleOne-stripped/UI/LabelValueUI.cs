using TMPro;
using UnityEngine;

namespace ScheduleOne.UI;
public class LabelValueUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private TextMeshProUGUI _labelText;
    [SerializeField]
    private TextMeshProUGUI _valueText;
    public void Set(string label, string value);
    public void SetLabel(string label);
    public void SetValue(string value);
}