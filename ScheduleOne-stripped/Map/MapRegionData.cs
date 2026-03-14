using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Audio;
using ScheduleOne.Economy;
using ScheduleOne.Levelling;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Relation;
using UnityEngine;

namespace ScheduleOne.Map;
[Serializable]
public class MapRegionData
{
    [Serializable]
    public class RegionContainer
    {
        public EMapRegion Region;
    }

    public EMapRegion Region;
    public string Name;
    public bool UnlockedByDefault;
    public FullRank RankRequirement;
    public NPC[] StartingNPCs;
    public Sprite RegionSprite;
    public DeliveryLocation[] RegionDeliveryLocations;
    public RegionContainer[] AdjacentRegions;
    public PolygonalZone RegionBounds;
    public bool IsUnlocked { get; private set; }

    public DeliveryLocation GetRandomUnscheduledDeliveryLocation();
    public void SetUnlocked();
    public List<EMapRegion> GetAdjacentRegions();
}