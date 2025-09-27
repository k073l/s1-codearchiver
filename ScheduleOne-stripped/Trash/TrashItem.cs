using System;
using System.Collections.Generic;
using FishNet;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dragging;
using ScheduleOne.Equipping;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Trash;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Draggable))]
[RequireComponent(typeof(PhysicsDamageable))]
public class TrashItem : MonoBehaviour, IGUIDRegisterable, ISaveable
{
    public const float POSITION_CHANGE_THRESHOLD;
    public const float LINEAR_DRAG;
    public const float ANGULAR_DRAG;
    public const float MIN_Y;
    public const int INTERACTION_PRIORITY;
    public Rigidbody Rigidbody;
    public Draggable Draggable;
    [Header("Settings")]
    public string ID;
    [Range(0f, 5f)]
    public int Size;
    [Range(0f, 10f)]
    public int SellValue;
    public bool CanGoInContainer;
    public Collider[] colliders;
    private Vector3 lastPosition;
    public Action<TrashItem> onDestroyed;
    private bool collidersEnabled;
    private float timeOnPhysicsEnabled;
    public Guid GUID { get; protected set; }
    public ScheduleOne.Property.Property CurrentProperty { get; protected set; }
    public string SaveFolderName => "Trash_" + GUID.ToString().Substring(0, 6);
    public string SaveFileName => "Trash_" + GUID.ToString().Substring(0, 6);
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }

    protected void Awake();
    protected void Start();
    public virtual void InitializeSaveable();
    protected void OnValidate();
    protected void MinPass();
    protected void Hovered();
    protected void Interacted();
    public void SetGUID(Guid guid);
    public void SetVelocity(Vector3 velocity);
    public void DestroyTrash();
    public virtual void Deinitialize();
    private void OnDestroy();
    private void RecheckPosition();
    public virtual TrashItemData GetData();
    public virtual string GetSaveString();
    public virtual bool ShouldSave();
    private void RecheckProperty();
    public void SetContinuousCollisionDetection();
    public void SetDiscreteCollisionDetection();
    public void SetPhysicsActive(bool active);
    public void SetCollidersEnabled(bool enabled);
}