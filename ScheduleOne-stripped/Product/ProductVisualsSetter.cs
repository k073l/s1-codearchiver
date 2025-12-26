using System;
using UnityEngine;

namespace ScheduleOne.Product;
public abstract class ProductVisualsSetter : MonoBehaviour
{
    [Serializable]
    protected class MeshRendererInt
    {
        public MeshRenderer Renderer;
        public int MaterialIndex;
    }

    public Transform VisualsContainer;
    public abstract void ApplyVisuals(ProductDefinition productDefinition);
    public void ApplyVisuals(ProductItemInstance productInstance);
    public void ResetVisuals();
    protected bool TryCastProductDefinition<T>(ProductDefinition definition, out T castedDefinition)
        where T : ProductDefinition;
}