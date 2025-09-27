using System;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts.WateringCan;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Trash;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Equipping;
public class Equippable_TrashGrabber : Equippable_Viewmodel
{
    public const float TrashDropSpacing;
    [Header("References")]
    public Transform TrashContent;
    public Transform TrashContent_Min;
    public Transform TrashContent_Max;
    public Animation GrabAnim;
    public Transform Bin;
    public Transform BinRaisedPosition;
    public AudioSourceController TrashDropSound;
    [Header("Settings")]
    public float DropTime;
    public float DropForce;
    public Vector3 TrashDropOffset;
    public UnityEvent onPickup;
    private TrashGrabberInstance trashGrabberInstance;
    private Pose defaultBinPosition;
    private Vector3 defaultBinScale;
    public static Equippable_TrashGrabber Instance { get; private set; }
    public static bool IsEquipped => (Object)(object)Instance != (Object)null;
    private float currentDropTime { get; set; }
    private float timeSinceLastDrop { get; set; } = 100f;

    public override void Equip(ItemInstance item);
    public override void Unequip();
    protected override void Update();
    private void EjectTrash();
    private void OnDestroy();
    public void PickupTrash(TrashItem item);
    public int GetCapacity();
    private void RefreshVisuals();
}