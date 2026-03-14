using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Misc;
public class UtilityPole : MonoBehaviour
{
    public const float CABLE_CULL_DISTANCE;
    public const float CABLE_CULL_DISTANCE_SQR;
    public UtilityPole previousPole;
    public UtilityPole nextPole;
    public bool Connection1Enabled;
    public bool Connection2Enabled;
    public float LengthFactor;
    [Header("References")]
    public Transform cable1Connection;
    public Transform cable2Connection;
    public List<Transform> cable1Segments;
    public List<Transform> cable2Segments;
    public Transform Cable1Container;
    public Transform Cable2Container;
    [Button]
    public void Orient();
    [Button]
    public void DrawLines();
}