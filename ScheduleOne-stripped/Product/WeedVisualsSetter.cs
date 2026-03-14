using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core.Items.Framework;
using UnityEngine;

namespace ScheduleOne.Product;
public class WeedVisualsSetter : ProductVisualsSetter
{
    [Serializable]
    public class MeshMaterialSettings
    {
        public MeshRenderer Mesh;
        public List<WeedAppearanceSettings.EWeedAppearanceType> Materials;
    }

    public MeshMaterialSettings[] Meshes;
    public override void ApplyVisuals(ProductDefinition definition);
    private void OnValidate();
}