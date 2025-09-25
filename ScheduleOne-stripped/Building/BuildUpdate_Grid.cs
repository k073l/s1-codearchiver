using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildUpdate_Grid : BuildUpdate_Base
{
    public GameObject GhostModel;
    public GridItem BuildableItemClass;
    public ItemInstance ItemInstance;
    public float CurrentRotation;
    [Header("Settings")]
    public float detectionRange;
    public LayerMask detectionMask;
    public float rotation_Smoothing;
    public bool AllowRotation;
    protected bool validPosition;
    protected Material currentGhostMaterial;
    protected TileIntersection closestIntersection;
    private float verticalOffset;
    protected virtual void Start();
    protected virtual void Update();
    protected virtual void LateUpdate();
    protected void PositionObjectInFrontOfPlayer(float dist, bool sanitizeForward, bool buildPointAsOrigin);
    protected void CheckRotation();
    protected void ApplyRotation();
    private List<TileIntersection> GetRelevantIntersections(FootprintTile tile);
    protected virtual void CheckIntersections();
    protected void UpdateMaterials();
    protected virtual void Place();
    private Vector2 GetOriginCoordinate();
    private Grid GetHoveredGrid();
}