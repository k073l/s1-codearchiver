using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Stations;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class StationRecipeFieldUI : MonoBehaviour
{
    [Header("References")]
    public StationRecipeEntry RecipeEntry;
    public GameObject None;
    public GameObject Mixed;
    public GameObject ClearButton;
    public List<StationRecipeField> Fields { get; protected set; } = new List<StationRecipeField>();

    public void Bind(List<StationRecipeField> field);
    private void Refresh(StationRecipe newVal);
    private bool AreFieldsUniform();
    public void Clicked();
    private void OptionSelected(StationRecipe option);
    public void ClearClicked();
}