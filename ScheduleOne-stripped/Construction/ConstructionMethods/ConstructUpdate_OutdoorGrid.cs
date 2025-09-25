using System.Collections.Generic;
using ScheduleOne.Building;
using ScheduleOne.ConstructableScripts;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tiles;
using ScheduleOne.UI.Construction;
using UnityEngine;

namespace ScheduleOne.Construction.ConstructionMethods;
public class ConstructUpdate_OutdoorGrid : ConstructUpdate_Base
{
    [Header("Settings")]
    public LayerMask detectionMask;
    public Constructable_GridBased ConstructableClass;
    public Transform GhostModel;
    protected bool validPosition;
    public float currentRotation;
    protected Material currentGhostMaterial;
    protected ConstructionManager.WorldIntersection closestIntersection;
    private float listingPrice;
    protected virtual void Start();
    protected override void Update();
    protected override void LateUpdate();
    protected void CheckRotation();
    protected void ApplyRotation();
    protected virtual void CheckTileIntersections();
    protected void UpdateMaterials();
    private bool AreMetaReqsMet();
    protected virtual Constructable_GridBased PlaceNewConstructable();
    protected virtual void FinalizeMoveConstructable();
    private Vector2 GetOriginCoordinate();
}