using UnityEngine;

namespace ScheduleOne.Product;
public class MethVisualsSetter : ProductVisualsSetter
{
    public MeshRenderer[] CrystalMaterials;
    public override void ApplyVisuals(ProductDefinition definition);
}