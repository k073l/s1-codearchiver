using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class BrickPressCanvas : Singleton<BrickPressCanvas>
{
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public UIScreen UIScreen;
    public ItemSlotUI[] ProductSlotUIs;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public Button BeginButton;
    public bool isOpen { get; protected set; }
    public BrickPress Press { get; protected set; }

    protected override void Awake();
    protected override void Start();
    protected virtual void Update();
    public void SetIsOpen(BrickPress press, bool open, bool removeUI = true);
    public void BeginButtonPressed();
}