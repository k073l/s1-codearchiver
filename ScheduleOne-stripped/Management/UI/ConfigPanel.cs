using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Management.UI;
public class ConfigPanel : MonoBehaviour
{
    public void Bind(List<EntityConfiguration> configs, UIScreen screen = null);
    protected virtual void BindInternal(List<EntityConfiguration> configs);
    private void ConfigureScreen(UIScreen screen);
}