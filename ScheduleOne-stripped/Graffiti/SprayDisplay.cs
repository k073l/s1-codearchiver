using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.Graffiti;
[RequireComponent(typeof(SpraySurface))]
public class SprayDisplay : MonoBehaviour
{
    public SpraySurface SpraySurface;
    public DecalProjector Projector;
    private Material cachedMaterial;
    private void Awake();
    private void Redraw();
}