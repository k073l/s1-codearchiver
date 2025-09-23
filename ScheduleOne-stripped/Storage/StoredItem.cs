using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tiles;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace ScheduleOne.Storage;
public class StoredItem : MonoBehaviour
{
    [Header("References")]
    public Transform buildPoint;
    public List<CoordinateStorageFootprintTilePair> CoordinateFootprintTilePairs;
    private int footprintX;
    private int footprintY;
    protected InteractableObject intObj;
    protected List<CoordinatePair> coordinatePairs;
    protected float rotation;
    public int xSize;
    public int ySize;
    public StorableItemInstance item { get; protected set; }
    public bool Destroyed { get; private set; }
    public FootprintTile OriginFootprint => CoordinateFootprintTilePairs[0].tile;
    public int FootprintX { get; }
    public int FootprintY { get; }
    public IStorageEntity parentStorageEntity { get; protected set; }
    public StorageGrid parentGrid { get; protected set; }
    public List<CoordinatePair> CoordinatePairs => coordinatePairs;
    public float Rotation => rotation;
    public int totalArea => CoordinateFootprintTilePairs.Count;
    public bool canBePickedUp { get; protected set; } = true;
    public string noPickupReason { get; protected set; } = string.Empty;

    protected virtual void Awake();
    protected virtual void OnValidate();
    public virtual void InitializeStoredItem(StorableItemInstance _item, StorageGrid grid, Vector2 _originCoordinate, float _rotation);
    private void RefreshTransform();
    protected virtual void InitializeIntObj();
    public virtual void Destroy_Internal();
    public void DestroyStoredItem();
    public void ClearFootprintOccupancy();
    public void SetCanBePickedUp(bool _canBePickedUp, string _noPickupReason = "");
    public static void SetLayerRecursively(GameObject go, int layerNumber);
    public static List<StoredItem> RemoveReservedItems(List<StoredItem> itemList, Employee allowedReservant);
    public virtual GameObject CreateGhostModel(ItemInstance _item, Transform parent);
    public void SetFootprintTileVisiblity(bool visible);
    public void CalculateFootprintTileIntersections();
    public FootprintTile GetTile(Coordinate coord);
    public virtual void Hovered();
    public virtual void Interacted();
}