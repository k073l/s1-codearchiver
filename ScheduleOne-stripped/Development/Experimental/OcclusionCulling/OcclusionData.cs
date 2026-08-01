using UnityEngine;

namespace ScheduleOne.Development.Experimental.OcclusionCulling;
[CreateAssetMenu(fileName = "OcclusionData", menuName = "ScheduleOne/Occlusion Culling/Occlusion Data", order = 1)]
public class OcclusionData : ScriptableObject
{
    [SerializeField]
    [HideInInspector]
    public long[] Data;
}