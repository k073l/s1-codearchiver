using System;
using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
public class ShroomInstance : ProductItemInstance
{
    private static Coroutine _psychedelicEffectCoroutine;
    public override string Name { get; }
    private ShroomDefinition _shroomDefinition => base.Definition as ShroomDefinition;

    public ShroomInstance();
    public ShroomInstance(ItemDefinition definition, int quantity, EQuality quality, PackagingDefinition packaging = null);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public override ItemData GetItemData();
    public override void ApplyEffectsToNPC(NPC npc);
    public override void ClearEffectsFromNPC(NPC npc);
    public override void ApplyEffectsToPlayer(Player player);
    public override void ClearEffectsFromPlayer(Player player);
    private void ApplyEffectsToAvatar(Avatar avatar);
    private void ClearEffectsFromAvatar(Avatar avatar);
    private IEnumerator DoPsychedlicEffectBlend(PsychedelicFullScreenFeature.MaterialProperties targetMaterialProperties, float targetValuePercentage, float duration);
}