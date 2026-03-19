using System;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Building;
public class BuildManager : NetworkSingleton<BuildManager>
{
    [Serializable]
    public class BuildSound
    {
        public BuildableItemDefinition.EBuildSoundType Type;
        public AudioSourceController Sound;
    }

    public List<BuildSound> PlaceSounds;
    [Header("Materials")]
    public Material ghostMaterial_White;
    public Material ghostMaterial_Red;
    private bool NetworkInitialize___EarlyScheduleOne_002EBuilding_002EBuildManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EBuilding_002EBuildManagerAssembly_002DCSharp_002Edll_Excuted;
    public bool isBuilding { get; protected set; }
    public GameObject currentBuildHandler { get; protected set; }

    public void StartBuilding(ItemInstance item);
    public void StopBuilding();
    public void PlayBuildSound(BuildableItemDefinition.EBuildSoundType type, Vector3 point);
    public void DisableColliders(GameObject obj);
    public void DisableLights(GameObject obj);
    public void DisableNetworking(GameObject obj);
    public void DisableSpriteRenderers(GameObject obj);
    public void ApplyMaterial(GameObject obj, Material mat, bool allMaterials = true);
    public void DisableNavigation(GameObject obj);
    public void DisableCanvases(GameObject obj);
    public GridItem CreateGridItem(ItemInstance item, Grid grid, Vector2 originCoordinate, int rotation, string guid = "", Action<GridItem> onBeforeSpawn = null);
    public ProceduralGridItem CreateProceduralGridItem(ItemInstance item, int rotationAngle, List<CoordinateProceduralTilePair> matches, string guid = "");
    public SurfaceItem CreateSurfaceItem(ItemInstance item, Surface parentSurface, Vector3 relativePosition, Quaternion relativeRotation, string guid = "");
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}