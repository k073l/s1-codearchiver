using System.Collections.Generic;
using FishNet;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Trash;
public class TrashGenerationVolume : MonoBehaviour
{
    public enum EPrefabSource
    {
        DefaultTrashPrefabs,
        CustomTrashPrefabs
    }

    [Header("Volume Settings")]
    [SerializeField]
    private Vector3 _volumeSize;
    [SerializeField]
    private Vector3 _volumeCenter;
    [Header("Trash Settings")]
    [SerializeField]
    private int _minTrashCount;
    [SerializeField]
    private int _maxTrashCount;
    [SerializeField]
    private EPrefabSource _prefabSource;
    [SerializeField]
    private List<TrashItem> _customTrashPrefabs;
    public void GenerateRandomAmount();
    public void Generate(int amount);
    private TrashItem GetSpawnableTrashPrefab();
    private void OnDrawGizmos();
}