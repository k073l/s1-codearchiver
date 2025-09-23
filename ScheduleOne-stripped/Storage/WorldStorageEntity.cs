using System;
using System.Collections.Generic;
using EasyButtons;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.Storage;
public class WorldStorageEntity : StorageEntity, IGUIDRegisterable, ISaveable
{
    public static List<WorldStorageEntity> All;
    [SerializeField]
    protected string BakedGUID;
    public GameDateTime LastContentChangeTime;
    private bool NetworkInitialize___EarlyScheduleOne_002EStorage_002EWorldStorageEntityAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EStorage_002EWorldStorageEntityAssembly_002DCSharp_002Edll_Excuted;
    public Guid GUID { get; protected set; }
    public string SaveFolderName => "Entity_" + GUID.ToString().Substring(0, 6);
    public string SaveFileName => "Entity_" + GUID.ToString().Substring(0, 6);
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>
    {
        "Contents"
    };
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }

    [Button]
    public void RegenerateGUID();
    public override void Awake();
    protected override void OnDestroy();
    public virtual void InitializeSaveable();
    public void SetGUID(Guid guid);
    public virtual bool ShouldSave();
    public WorldStorageEntityData GetSaveData();
    public virtual string GetSaveString();
    public virtual void Load(WorldStorageEntityData data);
    protected override void ContentsChanged();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EStorage_002EWorldStorageEntity_Assembly_002DCSharp_002Edll();
}