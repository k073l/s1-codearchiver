using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildUpdate_Surface : BuildUpdate_Base
{
    public GameObject GhostModel;
    public SurfaceItem BuildableItemClass;
    public ItemInstance ItemInstance;
    public float CurrentRotation;
    [Header("Settings")]
    public LayerMask DetectionMask;
    protected bool validPosition;
    protected Material currentGhostMaterial;
    protected Surface hoveredValidSurface;
    private float detectionRange => Mathf.Max(BuildableItemClass.HoldDistance, 4f);

    protected virtual void Start();
    protected virtual void Update();
    protected virtual void LateUpdate();
    protected void PositionObjectInFrontOfPlayer(float dist, bool sanitizeForward);
    private bool IsSurfaceValidForItem(Surface surface, Collider hitCollider, Vector3 hitPoint);
    protected void CheckRotation();
    protected void UpdateMaterials();
    protected virtual void Place();
}