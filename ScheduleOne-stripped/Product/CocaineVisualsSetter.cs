using UnityEngine;

namespace ScheduleOne.Product;
public class CocaineVisualsSetter : ProductVisualsSetter
{
    public MeshRenderer[] RockMeshes;
    public override void ApplyVisuals(ProductDefinition definition);
}