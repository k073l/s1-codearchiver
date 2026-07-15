using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Input;
using UnityEngine;

namespace ScheduleOne.Building;
public abstract class BuildStart_Base : MonoBehaviour
{
    [SerializeField]
    private InputPromptsData inputPromptsData;
    private InputPromptsData[] loadedInputModules;
    public virtual void StartBuilding(ItemInstance item);
    protected virtual List<InputPromptsData> GetInputPromptsModules();
    private void OnDestroy();
    private void UnloadInputPrompts();
}