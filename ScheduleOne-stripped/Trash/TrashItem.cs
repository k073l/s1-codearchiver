using System;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Trash;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrashItemDraggable))]
[RequireComponent(typeof(PhysicsDamageable))]
public class TrashItem : MonoBehaviour, IGUIDRegisterable
{
    private const float LinearDrag;
    private const float AngularDrag;
    private const float ImpactForceMultiplier;
    [Header("Settings")]
    [SerializeField]
    [FormerlySerializedAs("ID")]
    private string Id;
    [Range(0f, 5f)]
    public int Size;
    [Range(0f, 10f)]
    public int SellValue;
    [SerializeField]
    [FormerlySerializedAs("CanGoInContainer")]
    private bool _canGoInTrashContainer;
    private Rigidbody _rigidbody;
    private TrashItemDraggable _draggable;
    public Guid GUID { get; protected set; }
    public string ID => Id;
    public Vector3 Velocity => _rigidbody.velocity;

    public event Action<TrashItem> onDestroyed;
    protected void Awake();
    public virtual void Initialize(Guid guid, Vector3 initialVelocity = default(Vector3));
    public virtual bool CanGoInTrashContainer();
    public bool IsBeingDragged();
    public void SetGUID(Guid guid);
    public void DestroyTrash();
    public virtual void OnDestroyed();
    public virtual TrashItemData GetData();
}