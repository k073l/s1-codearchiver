using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class QualityFieldUI : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI FieldLabel;
    public Button[] QualityButtons;
    public List<QualityField> Fields { get; protected set; } = new List<QualityField>();

    public void Bind(List<QualityField> field);
    private void Refresh(EQuality value);
    private bool AreFieldsUniform();
    public void ValueChanged(EQuality value);
    public void ChangeTargetQuality(int amt);
}