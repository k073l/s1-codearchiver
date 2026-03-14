using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne;
public class UIScreen : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Manually assign the UIPanel attached to this screen in editor.")]
    private List<UIPanel> panels;
    [SerializeField]
    [Tooltip("When selected, the input action in the inputDescriptor list will be active")]
    private List<InputDescriptor> inputDescriptors;
    [SerializeField]
    [Tooltip("Each screen support 1 active scroll rect to scroll. You can use uiScreen.ChangeActiveScrollRect(newScrollRect) to change the active scroll rect via script at runtime.")]
    private ScrollRect activeScrollRect;
    [SerializeField]
    [Tooltip("Add this screen to UIScreenManger on Start")]
    private bool addScreenOnStart;
    [SerializeField]
    [Tooltip("Add this screen to UIScreenManger on OnEnable")]
    private bool addScreenOnEnable;
    [SerializeField]
    [Tooltip("Remove this screen from UIScreenManger on OnDisable")]
    private bool removeScreenOnDisable;
    private UIPanel currentSelectedPanel;
    private bool isSelected;
    private bool wasNavPressedLastFrame;
    public bool IsSelected { get; set; }
    public UIPanel CurrentSelectedPanel => currentSelectedPanel;
    public IReadOnlyList<UIPanel> Panels => panels.AsReadOnly();

    private void Awake();
    protected virtual void OnAwake();
    private void Start();
    protected virtual void OnStarted();
    private void OnEnable();
    private void OnDisable();
    private void OnDestroy();
    protected virtual void OnDestroyed();
    protected virtual void Update();
    private void InitScreen();
    public void AddPanel(UIPanel panel);
    public void RemovePanel(UIPanel panel);
    public void ClearPanels();
    public void SetCurrentSelectedPanel(UISelectable overrideSelectable = null, bool scrollToChild = true);
    public void SetCurrentSelectedPanel(UIPanel panel, UISelectable overrideSelectable = null, bool scrollToChild = true);
    private void UpdateScrollbar();
    private void DetectInput();
    private void DetectScreenInputDescriptors();
    internal bool ForceNavigate(Vector2 navDir, Vector2 fromPos);
    private bool Navigate(Vector2 navDir, Vector2 fromPos);
    public void ChangeActiveScrollRect(ScrollRect newScrollRect);
}