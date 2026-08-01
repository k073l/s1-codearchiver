using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using ScheduleOne.Storage;
using ScheduleOne.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class StorageMenu : Singleton<StorageMenu>
{
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public TextMeshProUGUI TitleLabel;
    public TextMeshProUGUI SubtitleLabel;
    public RectTransform SlotContainer;
    public ItemSlotUI[] SlotsUIs;
    public GridLayoutGroup SlotGridLayout;
    public RectTransform CloseButtonContainer;
    public MonoState State;
    private Action _onClosedCallback;
    public bool IsOpen { get; protected set; }
    public StorageEntity OpenedStorageEntity { get; protected set; }

    protected override void Awake();
    protected override void Start();
    public virtual void Open(IItemSlotOwner owner, string title, string subtitle, Action onClosedCallback = null);
    public virtual void Open(StorageEntity entity, Action onClosedCallback = null);
    private void Open(string title, string subtitle, IItemSlotOwner owner, Action onClosedCallback);
    public void Close();
    private void OnClose();
    private void CloseMenu();
}