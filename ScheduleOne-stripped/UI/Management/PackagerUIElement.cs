using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Employees;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class PackagerUIElement : WorldspaceUIElement
{
    [Header("References")]
    public RectTransform[] StationRects;
    public Packager AssignedPackager { get; protected set; }

    public void Initialize(Packager packager);
    protected virtual void RefreshUI();
}