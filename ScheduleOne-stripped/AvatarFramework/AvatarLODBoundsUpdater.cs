using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework;
public class AvatarLODBoundsUpdater : MonoBehaviour
{
    public const float CHECK_RATE_SECONDS;
    public const float HIP_OFFSET_THRESHOLD;
    public Avatar Avatar;
    private List<LODGroup> lodGroups;
    private Vector3 hipOffsetOnLastRefresh;
    private void Awake();
    private void InfrequentUpdate();
    private void GetLODGroups();
    private void Recalculate();
}