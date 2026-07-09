using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class NPCManager : NetworkSingleton<NPCManager>, IBaseSaveable, ISaveable
{
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
    protected override void OnDestroy();
    public virtual void InitializeSaveable();
    public static NPC GetNPC(string id);
    public static List<NPC> GetNPCsInRegion(EMapRegion region);
    public virtual string GetSaveString();
    public List<Transform> GetOrderedDistanceWarpPoints(Vector3 origin);
    public virtual List<string> WriteData(string parentFolderPath);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCManager_Assembly_002DCSharp_002Edll();
}