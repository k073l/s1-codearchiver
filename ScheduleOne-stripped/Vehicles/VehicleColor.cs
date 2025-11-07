using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Vehicles.Modification;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class VehicleColor : MonoBehaviour
{
    [Serializable]
    public class BodyMesh
    {
        public MeshRenderer Renderer;
        public int MaterialIndex;
    }

    public BodyMesh[] BodyMeshes;
    public EVehicleColor DefaultColor;
    private EVehicleColor displayedColor;
    private bool initialColorApplied;
    private void Start();
    public virtual void ApplyColor(EVehicleColor col);
}