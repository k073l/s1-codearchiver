using System;
using System.Collections.Generic;
using ScheduleOne.EntityFramework;
using ScheduleOne.Lighting;
using ScheduleOne.Property;
using ScheduleOne.Temperature;
using UnityEngine;

namespace ScheduleOne.Tiles;
[Serializable]
public class Tile : MonoBehaviour
{
    public delegate void TileChange(Tile thisTile);
    public int x;
    public int y;
    [Header("Settings")]
    public float AvailableOffset;
    [Header("References")]
    public Grid OwnerGrid;
    public LightExposureNode LightExposureNode;
    [Header("Occupants")]
    public List<GridItem> BuildableOccupants;
    public List<FootprintTile> OccupantTiles;
    public TileChange onTileChanged;
    public Action<Tile, float> onTileTemperatureChanged;
    private float _cosmeticTileTemperature;
    private TemperatureEmitterInfo[] _cachedCosmeticTemperatureEmitters;
    private float _tileTemperature;
    private TemperatureEmitterInfo[] _cachedTemperatureEmitters;
    public float CosmeticTileTemperature { get; }
    public float TileTemperature { get; }

    public void InitializePropertyTile(int _x, int _y, float _available_Offset, Grid _ownerGrid);
    private void Awake();
    public void AddOccupant(GridItem occ, FootprintTile tile);
    public void RemoveOccupant(GridItem occ, FootprintTile tile);
    public virtual bool CanBeBuiltOn();
    public List<Tile> GetSurroundingTiles();
    public virtual bool IsIndoorTile();
    public void SetVisible(bool vis);
    private void OnCosmeticTemperatureEmittersChanged(string propertyCode, TemperatureEmitterInfo[] emitters);
    private void OnTemperatureEmittersChanged(TemperatureEmitterInfo[] emitters);
}