using ScheduleOne.Product;

namespace ScheduleOne.Packaging;
public class FilledPackaging_Equippable : Product_Equippable
{
    public MultiTypeVisualsSetter MultiTypeVisuals;
    protected override void ApplyProductVisuals(ProductItemInstance product);
}