using System;
using System.Collections.Generic;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class MetadataManager : Singleton<MetadataManager>, IBaseSaveable, ISaveable
{
    private MetadataLoader loader;
    public DateTime CreationDate { get; protected set; }
    public string CreationVersion { get; protected set; } = string.Empty;
    public string SaveFolderName => "Metadata";
    public string SaveFileName => "Metadata";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    protected override void Awake();
    public virtual void InitializeSaveable();
    public virtual string GetSaveString();
    public void Load(MetaData data);
}