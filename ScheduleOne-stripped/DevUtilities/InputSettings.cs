using System;

namespace ScheduleOne.DevUtilities;
[Serializable]
public class InputSettings
{
    public enum EActionMode
    {
        Press,
        Hold
    }

    public float MouseSensitivity;
    public bool InvertMouse;
    public EActionMode SprintMode;
    public string BindingOverrides;
}