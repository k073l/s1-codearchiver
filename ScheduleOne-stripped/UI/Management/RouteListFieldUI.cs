using System;
using System.Collections.Generic;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class RouteListFieldUI : MonoBehaviour
{
    [Header("References")]
    public string FieldText;
    public TextMeshProUGUI FieldLabel;
    public RouteEntryUI[] RouteEntries;
    public RectTransform MultiEditBlocker;
    public Button AddButton;
    public List<RouteListField> Fields { get; protected set; } = new List<RouteListField>();

    private void Start();
    public void Bind(List<RouteListField> field);
    private void Refresh(List<AdvancedTransitRoute> newVal);
    private void EntryDeleteClicked(RouteEntryUI entry);
    private void AddClicked();
    private void RouteChanged(ITransitEntity newEntity);
}