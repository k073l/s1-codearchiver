using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

namespace ScheduleOne.Pathfinding.Baking;
public class NavMeshBakeTool : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface[] _allSurfaces;
    [SerializeField]
    private NavMeshSurface _prebakeSurface;
    [SerializeField]
    private NavMeshCleaner _navMeshCleaner;
    private List<DisableGameObjectDuringNavMeshBake> _disabledObjects;
}