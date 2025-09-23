using ScheduleOne.ItemFramework;
using ScheduleOne.Packaging;
using ScheduleOne.Product;

namespace ScheduleOne.StationFramework;
public class CocaineStationItem : StationItem
{
    public FilledPackagingVisuals[] Visuals;
    public override void Initialize(StorableItemDefinition itemDefinition);
}