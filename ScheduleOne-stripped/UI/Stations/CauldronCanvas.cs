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
public class CauldronCanvas : Singleton<CauldronCanvas>
{
    [Header("References")]
    public Canvas Canvas;
    public GameObject Container;
    public List<ItemSlotUI> IngredientSlotUIs;
    public ItemSlotUI LiquidSlotUI;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public Button BeginButton;
    public bool isOpen { get; protected set; }
    public Cauldron Cauldron { get; protected set; }

    protected override void Awake();
    protected override void Start();
    protected virtual void Update();
    public void SetIsOpen(Cauldron cauldron, bool open, bool removeUI = true);
    public void BeginButtonPressed();
}