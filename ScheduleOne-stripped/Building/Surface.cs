using System;
using System.Collections.Generic;
using EasyButtons;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.Building;
public class Surface : MonoBehaviour, IGUIDRegisterable
{
    public enum ESurfaceType
    {
        Wall,
        Roof
    }

    public enum EFace
    {
        Front,
        Back,
        Top,
        Bottom,
        Left,
        Right
    }

    [Header("Settings")]
    public ESurfaceType SurfaceType;
    public List<EFace> ValidFaces;
    [SerializeField]
    protected string BakedGUID;
    public Guid GUID { get; protected set; }
    public Transform Container => ((Component)ParentProperty.Container).transform;

    [field: SerializeField]
    public ScheduleOne.Property.Property ParentProperty { get; private set; }

    [Button]
    public void RegenerateGUID();
    private void OnValidate();
    private void OnDrawGizmos();
    protected virtual void Awake();
    public void SetGUID(Guid guid);
    public Vector3 GetRelativePosition(Vector3 worldPosition);
    public Quaternion GetRelativeRotation(Quaternion worldRotation);
    public bool IsFrontFace(Vector3 point, Collider collider);
    public bool IsPointValid(Vector3 point, Collider hitCollider);
}