using System;
using UnityEngine;

namespace ScheduleOne.Misc;
public class ToggleableLightV2 : ToggleableLight
{
    [Serializable]
    public struct Group
    {
        public MeshRenderer[] Meshes;
        public int MaterialIndex;
        public Material OnMaterial;
        public Material OffMaterial;
    }

    public Group[] Groups;
    protected override void SetLights();
}