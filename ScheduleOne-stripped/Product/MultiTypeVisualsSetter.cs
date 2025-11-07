using UnityEngine;

namespace ScheduleOne.Product;
public class MultiTypeVisualsSetter : MonoBehaviour
{
    public WeedVisualsSetter WeedVisuals;
    public MethVisualsSetter MethVisuals;
    public CocaineVisualsSetter CocaineVisuals;
    private void Awake();
    public void ApplyVisuals(ProductItemInstance itemInstance);
    public void ApplyVisuals(ProductDefinition product);
    private void ResetVisuals();
}