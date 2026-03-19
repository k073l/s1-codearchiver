using System;
using System.Collections.Generic;
using FishNet;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;
using UnityEngine.AI;

namespace ScheduleOne.Trash;
[RequireComponent(typeof(BoxCollider))]
public class TrashGenerator : MonoBehaviour, IGUIDRegisterable, ISaveable
{
    public const float TRASH_GENERATION_FRACTION;
    public const float DEFAULT_TRASH_PER_M2;
    public static List<TrashGenerator> AllGenerators;
    [Range(1f, 200f)]
    [SerializeField]
    private int MaxTrashCount;
    [SerializeField]
    private int TrashCountMultiplier;
    [SerializeField]
    private List<TrashItem> generatedTrash;
    [Header("Settings")]
    public LayerMask GroundCheckMask;
    private BoxCollider boxCollider;
    public string StaticGUID;
    public string SaveFolderName => "Generator_" + GUID.ToString().Substring(0, 6);
    public string SaveFileName => "Generator_" + GUID.ToString().Substring(0, 6);
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public Guid GUID { get; protected set; }

    public void SetGUID(Guid guid);
    private void Awake();
    private void Start();
    public virtual void InitializeSaveable();
    private void OnValidate();
    private void OnDestroy();
    private void OnDrawGizmos();
    public void AddGeneratedTrash(TrashItem item);
    public void RemoveGeneratedTrash(TrashItem item);
    [Button]
    private void RegenerateGUID();
    [Button]
    private void AutoCalculateTrashCount();
    [Button]
    private void GenerateMaxTrash();
    private void SleepStart();
    private void GenerateTrash(int count);
    public bool ShouldSave();
    public virtual TrashGeneratorData GetSaveData();
    public string GetSaveString();
}