using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class BuildableItemLoader : Loader
{
    public virtual string ItemType => typeof(BuildableItemData).Name;

    public BuildableItemLoader();
    public override void Load(string mainPath);
    public virtual void Load(DynamicSaveData data);
    public BuildableItemData GetBuildableItemData(string mainPath);
    protected T GetData<T>(string mainPath)
        where T : BuildableItemData;
}