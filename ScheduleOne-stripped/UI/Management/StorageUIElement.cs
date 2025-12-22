using ScheduleOne.ObjectScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class StorageUIElement : WorldspaceUIElement
{
    public Image Icon;
    public PlaceableStorageEntity AssignedEntity { get; protected set; }

    public void Initialize(PlaceableStorageEntity entity);
    protected virtual void RefreshUI();
}