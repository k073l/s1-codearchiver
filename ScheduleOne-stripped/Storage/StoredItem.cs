using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Tiles;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Storage;
public class StoredItem : MonoBehaviour
{
    [Header("References")]
    public Transform buildPoint;
    public List<CoordinateStorageFootprintTilePair> CoordinateFootprintTilePairs;
    private int footprintX;
    private int footprintY;
    protected List<CoordinatePair> coordinatePairs;
    protected float rotation;
    public int xSize;
    public int ySize;
    public StorableItemInstance item { get; protected set; }
    public bool Destroyed { get; private set; }
    public FootprintTile OriginFootprint => CoordinateFootprintTilePairs[0].tile;
    public int FootprintX { get; }
    public int FootprintY { get; }
    public StorageGrid parentGrid { get; protected set; }
    public List<CoordinatePair> CoordinatePairs => coordinatePairs;
    public float Rotation => rotation;
    public int totalArea => CoordinateFootprintTilePairs.Count;

    protected virtual void Awake();
    public virtual void InitializeStoredItem(StorableItemInstance _item, StorageGrid grid, Vector2 _originCoordinate, float _rotation);
    private void RefreshTransform();
    public virtual void Destroy();
    public void ClearFootprintOccupancy();
    public void SetFootprintTileVisiblity(bool visible);
    public void CalculateFootprintTileIntersections();
    public FootprintTile GetTile(Coordinate coord);
}