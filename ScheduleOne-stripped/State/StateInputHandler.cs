using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Input;
using UnityEngine;

namespace ScheduleOne.State;
public class StateInputHandler
{
    private IState _state;
    private List<InputPromptReference> _activeModules;
    private bool _isActive;
    public StateInputHandler(IState state);
    public void SetActive(bool isActive);
    public void AddModule(InputPromptReference moduleRef);
    public void RemoveModule(string moduleId);
    public void LoadModules();
    private void LoadModule(InputPromptReference moduleRef);
    public void UnloadModules();
    private void UnloadModule(InputPromptReference moduleRef);
    public void OnInputModuleLoaded(InputPromptReference moduleRef);
    public void OnInputModuleUnloaded(string moduleId);
    private bool HasModuleRef(string id);
    public void CleanUp();
}