using UnityEngine;

namespace ScheduleOne;
public class UIContentPanel : UIPanel
{
    [SerializeField]
    [Tooltip("Default is ImmediateDirection. ImmediatelyDirection is suitable if selectables are placed in grid format. NearestDirectionAndDistance is suitable for non-grid format")]
    private UINavigationType uiPanelNavigationType;
    protected override void DetectInput();
    protected override bool Navigate(Vector2 navDir);
}