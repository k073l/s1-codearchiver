using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;

namespace ScheduleOne.Persistence;
public class GenericSaveablesManager : Singleton<GenericSaveablesManager>, IBaseSaveable, ISaveable
{
    protected List<IGenericSaveable> Saveables;
    private GenericSaveablesLoader loader;
    public string SaveFolderName => "GenericSaveables";
    public string SaveFileName => "GenericSaveables";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; } = true;
    public int LoadOrder { get; }

    protected override void Awake();
    public virtual void InitializeSaveable();
    public void RegisterSaveable(IGenericSaveable saveable);
    public virtual string GetSaveString();
    public void LoadSaveable(GenericSaveData data);
}