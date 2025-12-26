using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Equipping;
using ScheduleOne.Heatmap;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Misc;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.Temperature;
using ScheduleOne.UI;
using ScheduleOne.UI.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools;
public class ManagementClipboard_Equippable : Equippable_Viewmodel
{
    [Header("References")]
    public Transform Clipboard;
    public Transform LoweredPosition;
    public Transform RaisedPosition;
    public ToggleableLight Light;
    public SelectionInfoUI SelectionInfo;
    public TextMeshProUGUI OverrideText;
    private static bool _heatmapToggledOn;
    private ScheduleOne.Property.Property _propertyWithHeatmapShown;
    private static bool _canToggleHeatmap => TemperatureUtility.TemperatureSystemEnabled;

    public static bool ResetHeatmapToggle();
    public override void Equip(ItemInstance item);
    private void ShowInputPrompts();
    private void HideInputPrompts();
    public override void Unequip();
    protected override void Update();
    private bool CanToggleClipboard();
    private void UpdateHeatmap();
    private void ClearPropertyWithHeatmapShown();
    private void FullscreenEnter();
    private void FullscreenExit();
    public void OverrideClipboardText(string overriddenText);
    public void EndOverride();
}