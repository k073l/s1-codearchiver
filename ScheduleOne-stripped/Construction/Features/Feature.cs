using FishNet.Object;
using ScheduleOne.UI.Construction.Features;
using UnityEngine;

namespace ScheduleOne.Construction.Features;
public abstract class Feature : NetworkBehaviour
{
    public string featureName;
    public Sprite featureIcon;
    public Transform featureIconLocation;
    public GameObject featureInterfacePrefab;
    public bool disableRoofDisibility;
    private bool NetworkInitialize___EarlyScheduleOne_002EConstruction_002EFeatures_002EFeatureAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EConstruction_002EFeatures_002EFeatureAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void OnStartClient();
    public virtual FI_Base CreateInterface(Transform parent);
    public abstract void Default();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected virtual void Awake_UserLogic_ScheduleOne_002EConstruction_002EFeatures_002EFeature_Assembly_002DCSharp_002Edll();
}