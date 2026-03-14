using TMPro;
using UnityEngine;

namespace ScheduleOne;
public class UITab : UIPanel, INonNavigablePanel
{
    public enum CycleInputActionType
    {
        Primary,
        Secondary
    }

    public enum CycleDirection
    {
        Horizontal,
        Vertical
    }

    [SerializeField]
    [Tooltip("Set to true to looping of cycling behavior between the first and last selectables index.")]
    private bool allowLooping;
    [SerializeField]
    [Tooltip("The InputActions for cycling behavior.")]
    private CycleInputActionType cycleInputActionType;
    [SerializeField]
    [Tooltip("The InputActions for cycling behavior.")]
    private CycleDirection cycleDirection;
    [SerializeField]
    [Tooltip("UI display for cycle left")]
    private TextMeshProUGUI cycleLeftVisual;
    [SerializeField]
    [Tooltip("UI display for cycle right")]
    private TextMeshProUGUI cycleRightVisual;
    private float cycleTabTimer;
    private bool wasCycleTabPressedLastFrame;
    protected override void EarlyUpdate();
    private float GetCycleTabInputValue();
    private void CycleTab(float navDir, float delay, float speed);
    private bool Navigate(float navDir);
    private bool Navigate2(float navDir);
    protected override void HandleInputDeviceChanged(GameInput.InputDeviceType type);
}