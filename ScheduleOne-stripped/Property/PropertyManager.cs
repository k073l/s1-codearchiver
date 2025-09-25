using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.Property;
public class PropertyManager : Singleton<PropertyManager>, IBaseSaveable, ISaveable
{
    private PropertiesLoader loader;
    public string SaveFolderName => "Properties";
    public string SaveFileName => "Properties";
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
    public void LoadProperty(PropertyData propertyData, string dataString);
    public Property GetProperty(string code);
}