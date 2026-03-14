using System;
using System.Collections.Generic;
using ScheduleOne.Core.Items.Framework;
using UnityEngine;

namespace ScheduleOne.Product;
public class ShroomVisualsSetter : ProductVisualsSetter
{
    protected enum EShroomMaterialType
    {
        Mushroom,
        Bulk
    }

    [Serializable]
    protected class MeshMaterialSettings
    {
        public MeshRenderer Mesh;
        public List<EShroomMaterialType> Materials;
    }

    [SerializeField]
    private MeshMaterialSettings[] _meshes;
    public override void ApplyVisuals(ProductDefinition definition);
}