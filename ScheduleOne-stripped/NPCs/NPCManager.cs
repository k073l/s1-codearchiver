using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EasyButtons;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
public class NPCManager : NetworkSingleton<NPCManager>, IBaseSaveable, ISaveable
{
    [Serializable]
    [CompilerGenerated]
    private sealed class _003C_003Ec
    {
        public static readonly _003C_003Ec _003C_003E9;
        public static UnityAction _003C_003E9__31_0;
        public static Predicate<NPCInventory.RandomInventoryItem> _003C_003E9__38_0;
        internal void _003CStart_003Eb__31_0();
        internal bool _003CGetNPCsWithSewerKey_003Eb__38_0(NPCInventory.RandomInventoryItem x);
    }

    public static List<NPC> NPCRegistry;
    public Transform[] NPCWarpPoints;
    public Transform NPCContainer;
    [Header("Prefabs")]
    public NPCPoI NPCPoIPrefab;
    public NPCPoI PotentialCustomerPoIPrefab;
    public NPCPoI PotentialDealerPoIPrefab;
    private NPCsLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCManagerAssembly_002DCSharp_002Edll_Excuted;
    public string SaveFolderName => "NPCs";
    public string SaveFileName => "NPCs";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    public override void Awake();
    protected override void Start();
    public virtual void InitializeSaveable();
    public static NPC GetNPC(string id);
    public static List<NPC> GetNPCsInRegion(EMapRegion region);
    public virtual string GetSaveString();
    public List<Transform> GetOrderedDistanceWarpPoints(Vector3 origin);
    public virtual List<string> WriteData(string parentFolderPath);
    [Button]
    public void GetNPCsWithSewerKey();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCManager_Assembly_002DCSharp_002Edll();
}