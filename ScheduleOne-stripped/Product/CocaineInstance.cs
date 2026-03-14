using System;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
public class CocaineInstance : ProductItemInstance
{
    public CocaineInstance(ItemDefinition definition, int quantity, EQuality quality, PackagingDefinition packaging = null);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public override ItemData GetItemData();
    public override void ApplyEffectsToNPC(NPC npc);
    public override void ClearEffectsFromNPC(NPC npc);
    public override void ApplyEffectsToPlayer(Player player);
    public override void ClearEffectsFromPlayer(Player Player);
}