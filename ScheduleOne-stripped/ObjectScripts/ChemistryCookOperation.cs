using FishNet.Serializing.Helping;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Stations;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class ChemistryCookOperation
{
    [CodegenExclude]
    private StationRecipe recipe;
    public string RecipeID;
    public EQuality ProductQuality;
    public Color StartLiquidColor;
    public float LiquidLevel;
    public int CurrentTime;
    [CodegenExclude]
    public StationRecipe Recipe { get; }

    public ChemistryCookOperation(StationRecipe recipe, EQuality productQuality, Color startLiquidColor, float liquidLevel, int currentTime = 0);
    public ChemistryCookOperation(string recipeID, EQuality productQuality, Color startLiquidColor, float liquidLevel, int currentTime = 0);
    public ChemistryCookOperation();
    public void Progress(int mins);
    public bool IsComplete();
}