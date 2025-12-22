using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.FX;
public class PsychedelicFullScreenPass : ScriptableRenderPass
{
    private PsychedelicFullScreenFeature.Settings _settings;
    private RTHandle _source;
    private RTHandle _tempTexture;
    private Material _material;
    private static readonly int BLEND_ID;
    private static readonly int NOISE_SCALE_ID;
    private static readonly int PAN_SPEED_ID;
    private static readonly int DOES_BOUNCE_ID;
    private static readonly int AMPLITUDE_ID;
    public PsychedelicFullScreenPass(PsychedelicFullScreenFeature.Settings settings);
    public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData);
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData);
    public override void OnCameraCleanup(CommandBuffer cmd);
}