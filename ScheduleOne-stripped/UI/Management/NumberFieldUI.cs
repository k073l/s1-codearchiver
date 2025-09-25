using System.Collections.Generic;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class NumberFieldUI : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI FieldLabel;
    public Slider Slider;
    public TextMeshProUGUI ValueLabel;
    public TextMeshProUGUI MinValueLabel;
    public TextMeshProUGUI MaxValueLabel;
    public List<NumberField> Fields { get; protected set; } = new List<NumberField>();

    public void Bind(List<NumberField> field);
    private void Refresh(float newVal);
    private bool AreFieldsUniform();
    public void ValueChanged(float value);
}