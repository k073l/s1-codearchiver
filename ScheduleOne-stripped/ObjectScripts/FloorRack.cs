using System.Collections.Generic;
using ScheduleOne.Building;
using ScheduleOne.EntityFramework;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class FloorRack : GridItem, IProceduralTileContainer
{
    [Header("References")]
    public Transform leg_BottomLeft;
    public Transform leg_BottomRight;
    public Transform leg_TopLeft;
    public Transform leg_TopRight;
    public CornerObstacle obs_BottomLeft;
    public CornerObstacle obs_BottomRight;
    public CornerObstacle obs_TopLeft;
    public CornerObstacle obs_TopRight;
    public List<ProceduralTile> procTiles;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EFloorRackAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EFloorRackAssembly_002DCSharp_002Edll_Excuted;
    public List<ProceduralTile> ProceduralTiles => procTiles;

    public virtual void UpdateLegVisibility();
    protected void CockAndBalls(GameObject leg, CornerObstacle obs, int xOffset, int yOffset);
    private FloorRack GetFloorRackFromOccupants(List<GridItem> occs);
    public List<FloorRack> GetSurroundingRacks();
    public override bool CanShareTileWith(List<GridItem> obstacles);
    public override bool CanBeDestroyed(out string reason);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}