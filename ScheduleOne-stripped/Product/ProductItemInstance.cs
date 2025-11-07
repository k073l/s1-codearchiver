using System;
using System.Collections.Generic;
using System.Linq;
using FishNet.Serializing.Helping;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product.Packaging;
using ScheduleOne.Storage;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
public class ProductItemInstance : QualityItemInstance
{
    public string PackagingID;
    [CodegenExclude]
    private PackagingDefinition packaging;
    [CodegenExclude]
    public PackagingDefinition AppliedPackaging { get; }

    [CodegenExclude]
    public int Amount { get; }
    public override string Name => base.Name + (((Object)(object)packaging == (Object)null) ? " (Unpackaged)" : string.Empty);

    [CodegenExclude]
    public override Equippable Equippable => GetEquippable();

    [CodegenExclude]
    public override StoredItem StoredItem => GetStoredItem();

    [CodegenExclude]
    public override Sprite Icon => GetIcon();

    public ProductItemInstance();
    public ProductItemInstance(ItemDefinition definition, int quantity, EQuality quality, PackagingDefinition _packaging = null);
    public override bool CanStackWith(ItemInstance other, bool checkQuantities = true);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public virtual void SetPackaging(PackagingDefinition def);
    private Equippable GetEquippable();
    private StoredItem GetStoredItem();
    private Sprite GetIcon();
    public override ItemData GetItemData();
    public virtual float GetAddictiveness();
    public float GetSimilarity(ProductDefinition other, EQuality quality);
    public virtual void ApplyEffectsToNPC(NPC npc);
    public virtual void ClearEffectsFromNPC(NPC npc);
    public virtual void ApplyEffectsToPlayer(Player player);
    public virtual void ClearEffectsFromPlayer(Player Player);
    public override float GetMonetaryValue();
}