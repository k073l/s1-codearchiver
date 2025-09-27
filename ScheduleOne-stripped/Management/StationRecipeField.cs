using System.Collections.Generic;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.StationFramework;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class StationRecipeField : ConfigField
{
    public List<StationRecipe> Options;
    public UnityEvent<StationRecipe> onRecipeChanged;
    public StationRecipe SelectedRecipe { get; protected set; }

    public StationRecipeField(EntityConfiguration parentConfig);
    public void SetRecipe(StationRecipe recipe, bool network);
    public override bool IsValueDefault();
    public StationRecipeFieldData GetData();
    public void Load(StationRecipeFieldData data);
}