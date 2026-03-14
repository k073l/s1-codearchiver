using FishNet.Serializing;
using ScheduleOne.Product;

namespace ScheduleOne.ItemFramework;
public static class ItemSerializers
{
    public const string NullItem;
    public static void WriteItemInstance(this Writer writer, ItemInstance value);
    public static ItemInstance ReadItemInstance(this Reader reader);
    public static void WriteProductItemInstance(this Writer writer, ProductItemInstance value);
    public static ProductItemInstance ReadProductItemInstance(this Reader reader);
}