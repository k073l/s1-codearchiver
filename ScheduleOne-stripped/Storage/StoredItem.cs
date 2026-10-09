using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Tiles;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace ScheduleOne.Storage;
public class StoredItem : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform buildPoint;
    [HideInInspector]
    [SerializeField]
    [FormerlySerializedAs("CoordinateFootprintTilePairs")]
    private List<CoordinateStorageFootprintTilePair> _coordinateFootprintTilePairs;
    private float _rotation;
    private int _footprintX;
    private int _footprintY;
    private StorageGrid _parentGrid;
    private StorableItemInstance _itemInstance;
    private List<CoordinatePair> _coordinatePairs;
    private StoredItem _originalPrefab;
    public bool Initialized => _itemInstance != null;
    public int SizeX { get; }
    public int SizeY { get; }

    protected virtual void Awake();
    public void SetOriginalPrefab(StoredItem prefab);
    public virtual void InitializeStoredItem(StorableItemInstance item, StorageGrid grid, Vector2 originCoordinate, float rotation);
    public virtual void Destroy();
    public void ClearFootprintOccupancy();
    private void RefreshTransform();
    private FootprintTile GetTile(Coordinate coord);
}