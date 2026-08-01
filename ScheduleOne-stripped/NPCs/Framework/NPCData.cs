using System;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class NPCData
{
    [SerializeField]
    private ValueOrReference<BasicInfo, BasicInfoPreset> _basicInfo;
    [SerializeField]
    private ValueOrReference<Appearance, AppearancePreset> _appearance;
    [SerializeField]
    private ValueOrReference<Health, HealthPreset> _health;
    [SerializeField]
    private ValueOrReference<Movement, MovementPreset> _movement;
    [SerializeField]
    private ValueOrReference<Interaction, InteractionPreset> _interaction;
    [SerializeField]
    private ValueOrReference<Relationship, RelationshipPreset> _relationship;
    [SerializeField]
    private ValueOrReference<Messaging, MessagingPreset> _messaging;
    [SerializeField]
    private ValueOrReference<Dialogue, DialoguePreset> _dialogue;
    [SerializeField]
    private ValueOrReference<Voice, VoicePreset> _voice;
    [SerializeField]
    private ValueOrReference<Inventory, InventoryPreset> _inventory;
    [SerializeField]
    private ValueOrReference<Behaviour, BehaviourPreset> _behaviour;
    [SerializeField]
    private ValueOrReference<WeatherBehaviour, WeatherBehaviourPreset> _weatherBehaviour;
    public BasicInfo BasicInfo => _basicInfo.GetValue();
    public Appearance Appearance => _appearance.GetValue();
    public Health Health => _health.GetValue();
    public Movement Movement => _movement.GetValue();
    public Interaction Interaction => _interaction.GetValue();
    public Relationship Relationship => _relationship.GetValue();
    public Messaging Messaging => _messaging.GetValue();
    public Dialogue Dialogue => _dialogue.GetValue();
    public Voice Voice => _voice.GetValue();
    public Inventory Inventory => _inventory.GetValue();
    public Behaviour Behaviour => _behaviour.GetValue();
    public WeatherBehaviour WeatherBehaviour => _weatherBehaviour.GetValue();

    public virtual NPCData GetDeepCopy();
    protected void PopulateNPCData(NPCData data);
}