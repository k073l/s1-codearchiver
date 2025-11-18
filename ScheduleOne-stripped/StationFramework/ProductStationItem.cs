using ScheduleOne.ItemFramework;
using ScheduleOne.Product;

namespace ScheduleOne.StationFramework;
public class ProductStationItem : StationItem
{
    public ProductVisualsSetter Visuals;
    public override void Initialize(StorableItemDefinition itemDefinition);
}