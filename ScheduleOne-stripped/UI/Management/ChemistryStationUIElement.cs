using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using ScheduleOne.UI.Stations;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class ChemistryStationUIElement : WorldspaceUIElement
{
    [Header("References")]
    public StationRecipeEntry RecipeEntry;
    public GameObject NoRecipe;
    public ChemistryStation AssignedStation { get; protected set; }

    public void Initialize(ChemistryStation oven);
    protected virtual void RefreshUI();
}