using System;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tiles;
using ScheduleOne.Trash;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.ObjectScripts;
[RequireComponent(typeof(TrashContainer))]
public class TrashContainerItem : GridItem, ITransitEntity
{
    public const float MAX_VERTICAL_OFFSET;
    public TrashContainer Container;
    public ParticleSystem Flies;
    public AudioSourceController TrashAddedSound;
    public DecalProjector PickupAreaProjector;
    public Transform[] accessPoints;
    [Header("Pickup settings")]
    public bool UsableByCleaners;
    public float PickupSquareWidth;
    public List<TrashItem> TrashItemsInRadius;
    public List<TrashBag> TrashBagsInRadius;
    private float calculatedPickupRadius;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002ETrashContainerItemAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002ETrashContainerItemAssembly_002DCSharp_002Edll_Excuted;
    public string Name => GetManagementName();
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => ((Component)this).transform;
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; }
    public bool IsAcceptingItems { get; set; }

    public override void Awake();
    protected override void Start();
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    private void TrashLevelChanged();
    public override bool CanBeDestroyed(out string reason);
    public override BuildableItemData GetBaseData();
    private void TrashAdded(string trashID);
    public override void ShowOutline(Color color);
    public override void HideOutline();
    private void CheckTrashItems();
    private void AddTrashToRadius(TrashItem trashItem);
    private void AddTrashBagToRadius(TrashBag trashBag);
    private void RemoveTrashItemFromRadius(TrashItem trashItem);
    private void RemoveTrashBagFromRadius(TrashBag trashBag);
    private bool IsTrashValid(TrashItem trashItem);
    public bool IsPointInPickupZone(Vector3 point);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EObjectScripts_002ETrashContainerItem_Assembly_002DCSharp_002Edll();
}