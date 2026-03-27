using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.UI.Input;
using UnityEngine;

namespace ScheduleOne.UI.Management;
public class ManagementWorldspaceCanvas : Singleton<ManagementWorldspaceCanvas>
{
    public const float VISIBILITY_RANGE;
    public const float PROPERTY_CANVAS_RANGE;
    [Header("References")]
    public Canvas Canvas;
    public AnimationCurve ScaleCurve;
    public TransitLineVisuals TransitRouteVisualsPrefab;
    public InputPrompt CrosshairPrompt;
    [Header("Settings")]
    public LayerMask ObjectSelectionLayerMask;
    public Color HoveredOutlineColor;
    public Color SelectedOutlineColor;
    private List<IConfigurable> ShownConfigurables;
    public IConfigurable HoveredConfigurable;
    private IConfigurable OutlinedConfigurable;
    public List<IConfigurable> SelectedConfigurables;
    public bool IsOpen { get; protected set; }
    public ScheduleOne.Property.Property CurrentProperty => Singleton<PropertyManager>.Instance.GetNearestProperty(((Component)PlayerSingleton<PlayerCamera>.Instance).transform.position);

    public void Open();
    public void Close(bool preserveSelection = false);
    private void Update();
    private void UpdateInputPrompt();
    private void UpdateUIs();
    private void LateUpdate();
    private void UpdateSelection();
    private void AddToSelection(IConfigurable config);
    private void RemoveFromSelection(IConfigurable config);
    private void ClearSelection();
    private void RemoveNullConfigurables();
    private IConfigurable GetHoveredConfigurable();
    private List<IConfigurable> GetConfigurablesToShow();
    public void ShowCrosshairPrompt(string message);
    public void HideCrosshairPrompt();
}