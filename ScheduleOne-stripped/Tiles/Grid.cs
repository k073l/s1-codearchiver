using System;
using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.EntityFramework;
using ScheduleOne.Property;
using ScheduleOne.Temperature;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Tiles;
public class Grid : MonoBehaviour, IGUIDRegisterable
{
    public const float TileSize;
    public List<Tile> Tiles;
    public List<CoordinateTilePair> CoordinateTilePairs;
    [SerializeField]
    private ScheduleOne.Property.Property _parentProperty;
    [FormerlySerializedAs("StaticGUID")]
    [SerializeField]
    private string _guid;
    public Action<string, TemperatureEmitterInfo[]> OnCosmeticTemperatureEmittersChanged;
    public Action<TemperatureEmitterInfo[]> OnTemperatureEmittersChanged;
    protected Dictionary<Coordinate, Tile> _coordinateToTile;
    protected List<TemperatureEmitter> _cosmeticTemperatureEmitters;
    protected List<TemperatureEmitter> _temperatureEmitters;
    private bool _cosmeticEmittersChangedThisFrame;
    private bool _emittersChangedThisFrame;
    public Guid GUID { get; protected set; }
    public ScheduleOne.Property.Property ParentProperty => _parentProperty;
    public Transform Container => ((Component)ParentProperty.Container).transform;
    public Vector3 Origin => ((Component)this).transform.position;
    public TemperatureEmitterInfo[] TemperatureEmitterInfos { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    protected virtual void Awake();
    private void LateUpdate();
    private void ProcessCoordinateDataPairs();
    public void RegisterTile(Tile tile);
    public void DeregisterTile(Tile tile);
    [Button]
    public void RegenerateGUID();
    public void SetGUID(Guid guid);
    public Coordinate GetMatchedCoordinate(FootprintTile tileToMatch);
    public bool IsTileValidAtCoordinate(Coordinate gridCoord, FootprintTile tile, GridItem tileOwner = null);
    public Tile GetTile(Coordinate coord);
    [Button]
    public void SetVisible();
    [Button]
    public void SetInvisible();
    public void AddTemperatureEmitter(TemperatureEmitter emitter, bool onlyCosmetic);
    public void RemoveTemperatureEmitter(TemperatureEmitter emitter, bool onlyCosmetic);
    private void CosmeticTemperatureEmittersChanged();
    private void TemperatureEmittersChanged();
    private void SetGridSize();
}