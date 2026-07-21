using System;
using UnityEngine.InputSystem;

namespace ScheduleOne.CustomUI;
[Serializable]
public class ActionBindingReference
{
    public InputActionReference ActionReference;
    public string BindingId;
}