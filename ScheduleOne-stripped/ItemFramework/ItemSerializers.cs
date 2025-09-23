using FishNet.Serializing;
using ScheduleOne.Clothing;
using ScheduleOne.ObjectScripts.WateringCan;
using ScheduleOne.Product;
using ScheduleOne.Storage;

namespace ScheduleOne.ItemFramework;
public static class ItemSerializers
{
    public const bool DEBUG;
    private static ItemInstance Read(this Reader reader);
    public static void WriteItemInstance(this Writer writer, ItemInstance value);
    public static ItemInstance ReadItemInstance(this Reader reader);
    private static ItemInstance DirectReadItemInstance(this Reader reader);
    public static void WriteStorableItemInstance(this Writer writer, StorableItemInstance value);
    public static StorableItemInstance ReadStorableItemInstance(this Reader reader);
    private static StorableItemInstance DirectReadStorableItemInstance(this Reader reader);
    public static void WriteCashInstance(this Writer writer, CashInstance value);
    public static CashInstance ReadCashInstance(this Reader reader);
    private static CashInstance DirectReadCashInstance(this Reader reader);
    public static void WriteQualityItemInstance(this Writer writer, QualityItemInstance value);
    public static QualityItemInstance ReadQualityItemInstance(this Reader reader);
    private static QualityItemInstance DirectReadQualityItemInstance(this Reader reader);
    public static void WriteClothingInstance(this Writer writer, ClothingInstance value);
    public static ClothingInstance ReadClothingInstance(this Reader reader);
    private static ClothingInstance DirectReadClothingInstance(this Reader reader);
    public static void WriteProductItemInstance(this Writer writer, ProductItemInstance value);
    public static ProductItemInstance ReadProductItemInstance(this Reader reader);
    private static ProductItemInstance DirectReadProductItemInstance(this Reader reader);
    public static void WriteWeedInstance(this Writer writer, WeedInstance value);
    public static WeedInstance ReadWeedInstance(this Reader reader);
    private static WeedInstance DirectReadWeedInstance(this Reader reader);
    public static void WriteMethInstance(this Writer writer, MethInstance value);
    public static MethInstance ReadMethInstance(this Reader reader);
    private static MethInstance DirectReadMethInstance(this Reader reader);
    public static void WriteCocaineInstance(this Writer writer, CocaineInstance value);
    public static CocaineInstance ReadCocaineInstance(this Reader reader);
    private static CocaineInstance DirectReadCocaineInstance(this Reader reader);
    public static void WriteIntegerItemInstance(this Writer writer, IntegerItemInstance value);
    public static IntegerItemInstance ReadIntegerItemInstance(this Reader reader);
    private static IntegerItemInstance DirectReadIntegerItemInstance(this Reader reader);
    public static void WriteWateringCanInstance(this Writer writer, WateringCanInstance value);
    public static WateringCanInstance ReadWateringCanInstance(this Reader reader);
    private static WateringCanInstance DirectReadWateringCanInstance(this Reader reader);
    public static void WriteTrashGrabberInstance(this Writer writer, TrashGrabberInstance value);
    public static TrashGrabberInstance ReadTrashGrabberInstance(this Reader reader);
    private static TrashGrabberInstance DirectReadTrashGrabberInstance(this Reader reader);
}