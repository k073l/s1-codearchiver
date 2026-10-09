using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.UI.Handover;
public abstract class HandoverScreenMode : MonoBehaviour
{
    protected HandoverScreen _mainScreen => Singleton<HandoverScreen>.Instance;

    protected abstract void OnHandoverItemsChanged(List<ItemInstance> items);
    public virtual void Cancel();
    public virtual void Submit();
    protected virtual void OnOpen();
    protected virtual void OnClose();
}