using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.PlayerTasks;
public class ApplyShroomSpawnTask : Task
{
    private enum EStage
    {
        BreakUpChunks,
        MixIntoSoil
    }

    private const float DistanceBetweenMixes;
    private const float MixRadius;
    private const int MaskTextureSize;
    private const int SmallChunkCount;
    private ShroomSpawnDefinition _spawnDefinition;
    private MushroomBed _mushroomBed;
    private SpawnChunk _baseSpawnChunk;
    private EStage _currentStage;
    private DecalProjector _mixProjector;
    private Vector3 _lastMixPosition;
    private Texture2D _maskingTexture;
    private List<SpawnChunk> _mixedChunks;
    private bool _mixMouseUp;
    public ApplyShroomSpawnTask(MushroomBed mushroomBed, ShroomSpawnDefinition spawnDefinition);
    public override void StopTask();
    public override void Success();
    public override void Update();
    public override void LateUpdate();
    private void UpdateInstructionText();
    private void UpdateProgression();
    private bool GetCursorHoverOnSoil(out Vector3 hitPoint);
    private void TriggerMix(Vector3 mixPoint);
    private void PaintMask(int x, int y);
    private Texture2D CreateMaskTexture();
}