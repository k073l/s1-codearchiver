using System;
using System.Collections.Generic;
using EPOOutline;
using FluffyUnderware.DevTools.Extensions;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Map;
using ScheduleOne.Property;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Delivery;
public class LoadingDock : MonoBehaviour, IGUIDRegisterable, ITransitEntity
{
    [SerializeField]
    protected string BakedGUID;
    public ScheduleOne.Property.Property ParentProperty;
    public VehicleDetector VehicleDetector;
    public ParkingLot Parking;
    public Transform uiPoint;
    public Transform[] accessPoints;
    public GameObject[] OutlineRenderers;
    private Outlinable OutlineEffect;
    public LandVehicle DynamicOccupant { get; private set; }
    public LandVehicle StaticOccupant { get; private set; }
    public bool IsInUse { get; }
    public Guid GUID { get; protected set; }
    public string Name => "Loading Dock " + (ArrayExt.IndexOf<LoadingDock>(ParentProperty.LoadingDocks, this) + 1);
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => uiPoint;
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; } = true;
    public bool IsAcceptingItems { get; set; }
    public bool IsDestroyed { get; set; }

    [Button]
    public void RegenerateGUID();
    private void Awake();
    private void Start();
    public void SetGUID(Guid guid);
    private void RefreshOccupant();
    private void SetOccupant(LandVehicle occupant);
    public void SetStaticOccupant(LandVehicle vehicle);
    public virtual void ShowOutline(Color color);
    public virtual void HideOutline();
}