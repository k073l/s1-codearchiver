using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class LabOvenCanvas : Singleton<LabOvenCanvas>
{
    [Header("References")]
    public Canvas Canvas;
    public GameObject Container;
    public UIScreen UIScreen;
    public ItemSlotUI IngredientSlotUI;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public TextMeshProUGUI ErrorLabel;
    public Button BeginButton;
    public TextMeshProUGUI BeginButtonLabel;
    public RectTransform ProgressContainer;
    public Image IngredientIcon;
    public Image ProgressImg;
    public Image ProductIcon;
    public bool isOpen { get; protected set; }
    public LabOven Oven { get; protected set; }

    protected override void Awake();
    protected override void Start();
    protected virtual void Update();
    public void SetIsOpen(LabOven oven, bool open, bool removeUI = true);
    public void BeginButtonPressed();
    public bool CanBegin();
    private bool DoesOvenOutputHaveSpace();
    private void RefreshActiveOperation();
}