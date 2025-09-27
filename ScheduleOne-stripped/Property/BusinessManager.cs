using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.Property;
public class BusinessManager : Singleton<BusinessManager>, IBaseSaveable, ISaveable
{
    private BusinessesLoader loader;
    public string SaveFolderName => "Businesses";
    public string SaveFileName => "Businesses";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => true;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; } = true;
    public int LoadOrder { get; }

    protected override void Awake();
    public virtual void InitializeSaveable();
    public virtual string GetSaveString();
    public virtual List<string> WriteData(string parentFolderPath);
    public virtual void DeleteUnapprovedFiles(string parentFolderPath);
    public void LoadBusiness(BusinessData businessData, string dataString);
}