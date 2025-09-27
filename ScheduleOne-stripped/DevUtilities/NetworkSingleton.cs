using FishNet.Object;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public abstract class NetworkSingleton<T> : NetworkBehaviour where T : NetworkSingleton<T>
{
    private static T instance;
    protected bool Destroyed;
    private bool NetworkInitialize___EarlyScheduleOne_002EDevUtilities_002ENetworkSingleton_00601Assembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EDevUtilities_002ENetworkSingleton_00601Assembly_002DCSharp_002Edll_Excuted;
    public static bool InstanceExists => (Object)(object)instance != (Object)null;
    public static T Instance { get; protected set; }

    protected virtual void Start();
    public override void Awake();
    protected virtual void OnDestroy();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected virtual void Awake_UserLogic_ScheduleOne_002EDevUtilities_002ENetworkSingleton_00601_Assembly_002DCSharp_002Edll();
}