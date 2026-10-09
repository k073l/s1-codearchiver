using System;
using UnityEngine;

namespace ScheduleOne.AvatarFramework;
[RequireComponent(typeof(Avatar))]
public class AvatarLODBoundsUpdater : MonoBehaviour
{
    private const float CheckInterval;
    private const float HipOffsetThreshold;
    [SerializeField]
    private LODGroup[] _lodGroups;
    private Avatar _avatar;
    private Vector3 _hipOffsetOnLastRefresh;
    private void Awake();
    private void InfrequentUpdate();
    private void OnRagdollChange(bool isRagdolled);
    private void Recalculate();
}