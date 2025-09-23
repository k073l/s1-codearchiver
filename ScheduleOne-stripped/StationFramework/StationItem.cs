using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Trash;
using UnityEngine;

namespace ScheduleOne.StationFramework;
public class StationItem : MonoBehaviour
{
    public List<ItemModule> Modules;
    public TrashItem TrashPrefab;
    public List<ItemModule> ActiveModules { get; protected set; } = new List<ItemModule>();

    protected virtual void Awake();
    public virtual void Initialize(StorableItemDefinition itemDefinition);
    public void ActivateModule<T>()
        where T : ItemModule;
    public void Destroy();
    public bool HasModule<T>()
        where T : ItemModule;
    public T GetModule<T>()
        where T : ItemModule;
}