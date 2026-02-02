using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Object;
using GameKit.Utilities;
using ScheduleOne.DevUtilities;
using ScheduleOne.Graffiti;
using ScheduleOne.Map;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class SprayGraffiti : CartelActivity
{
    [Header("Settings")]
    [SerializeField]
    private float _minimumDistanceFromPlayers;
    private WorldSpraySurface _validSpraySurface;
    public override bool IsRegionValidForActivity(EMapRegion region);
    public void SetSpraySurface(EMapRegion region, bool overrideExisting = true);
    public override void Activate(EMapRegion region);
}