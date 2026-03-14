using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne;
public class UIPopupScreen_ContextMenu : UIPopupScreen
{
    public class ContextMenuOption
    {
        public int optionID;
        public string optionName;
        public Action optionAction;
        public ContextMenuOption(int id, string name, Action action);
    }

    public enum AnchorType
    {
        TopLeft,
        BottomLeft,
        Center
    }

    [SerializeField]
    [Tooltip("Prefab for the Option Selectable")]
    private UISelectable selectablePrefab;
    [SerializeField]
    [Tooltip("Transform where the Option Selectables will be parented to")]
    private Transform contentParent;
    [SerializeField]
    [Tooltip("RectTransform where the anchoring point of the context menu will be")]
    private RectTransform anchorRectTransform;
    [SerializeField]
    [Tooltip("Canvas to control the visibility")]
    private Canvas canvas;
    [SerializeField]
    [Tooltip("Screen blocker to block mouse interaction with ui elements behind the context menu and darken the background")]
    private GameObject screenBlocker;
    private AnchorType anchor;
    private List<ContextMenuOption> options;
    private Queue<UISelectable> selectablePool;
    private Dictionary<int, UISelectable> activeSelectables;
    public AnchorType Anchor { get; set; }

    protected override void OnAwake();
    protected override void OnStarted();
    protected override void OnDestroyed();
    private void HandleInputDeviceChanged(GameInput.InputDeviceType type);
    public void AddOption(int id, string name, Action action);
    public override void Close();
    private void Open();
    public override void Open(params object[] args);
    private void Clear();
    private void SelectPanel(int selectedIndex);
    private UISelectable GetSelectableFromPool();
    private void SetPosition(Vector2 pos);
}