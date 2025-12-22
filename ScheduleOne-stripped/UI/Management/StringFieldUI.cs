using System.Collections.Generic;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class StringFieldUI : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI FieldLabel;
    public TMP_InputField InputField;
    public List<StringField> Fields { get; protected set; } = new List<StringField>();

    public void Bind(List<StringField> field);
    private void Refresh(string newVal);
    private bool AreFieldsUniform();
    public void ValueChanged(string value);
}