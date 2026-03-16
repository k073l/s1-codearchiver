using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Equipping;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.Trash;
public class TrashBag_Equippable : Equippable_Viewmodel
{
    public const float TRASH_CONTAINER_INTERACT_DISTANCE;
    public const float BAG_TRASH_TIME;
    public const float PICKUP_RANGE;
    public const float PICKUP_AREA_RADIUS;
    public LayerMask PickupLookMask;
    [Header("References")]
    public DecalProjector PickupAreaProjector;
    public AudioSourceController RustleSound;
    public AudioSourceController BagSound;
    private float _bagTrashTime;
    private TrashContainer _baggedContainer;
    private float _pickupTrashTime;
    public static bool IsHoveringTrash => ((Component)Singleton<TrashBagCanvas>.Instance.InputPrompt).gameObject.activeSelf;
    public bool IsBaggingTrash { get; private set; }
    public bool IsPickingUpTrash { get; private set; }

    public override void Equip(ItemInstance item);
    public override void Unequip();
    protected override void Update();
    private TrashContainer GetHoveredTrashContainer();
    private bool RaycastLook(out RaycastHit hit);
    private bool IsPickupLocationValid(RaycastHit hit);
    private List<TrashItem> GetTrashItemsAtPoint(Vector3 pos);
    private void StartBagTrash(TrashContainer container);
    private void StopBagTrash(bool complete);
    private void StartPickup();
    private void StopPickup(bool complete);
}