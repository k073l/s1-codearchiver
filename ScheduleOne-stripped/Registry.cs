using System;
using System.Collections.Generic;
using EasyButtons;
using FishNet.Object;
using ScheduleOne.ConstructableScripts;
using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Levelling;
using ScheduleOne.Persistence;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne;
public class Registry : PersistentSingleton<Registry>
{
    [Serializable]
    public class ObjectRegister
    {
        public string ID;
        public string AssetPath;
        public NetworkObject Prefab;
    }

    [Serializable]
    public class ItemRegister
    {
        [HideInInspector]
        public string name;
        public string ID;
        public string AssetPath;
        public ItemDefinition Definition;
    }

    [SerializeField]
    private List<ObjectRegister> ObjectRegistry;
    [SerializeField]
    private List<ItemRegister> ItemRegistry;
    [SerializeField]
    private List<ItemRegister> ItemsAddedAtRuntime;
    private Dictionary<int, ItemRegister> ItemDictionary;
    private Dictionary<string, string> itemIDAliases;
    public List<SeedDefinition> Seeds;
    private void OnValidate();
    protected override void Awake();
    public static GameObject GetPrefab(string id);
    public static ItemDefinition GetItem(string ID);
    public static bool ItemExists(string ID);
    public static T GetItem<T>(string ID)
        where T : ItemDefinition;
    public ItemDefinition _GetItem(string ID, bool warnIfNonExistent = true);
    public static Constructable GetConstructable(string id);
    private static int GetHash(string ID);
    private static string RemoveAssetsAndPrefab(string originalString);
    protected override void Start();
    public void AddToRegistry(ItemDefinition item);
    public List<ItemDefinition> GetAllItems();
    private void AddToItemDictionary(ItemRegister reg);
    private void RemoveItemFromDictionary(ItemRegister reg);
    public void RemoveRuntimeItems();
    public void RemoveFromRegistry(ItemDefinition item);
    [Button]
    public void LogOrderedUnlocks();
}