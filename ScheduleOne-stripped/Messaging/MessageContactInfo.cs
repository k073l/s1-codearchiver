using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Framework;
using UnityEngine;

namespace ScheduleOne.Messaging;
public struct MessageContactInfo
{
    private string _name;
    private string _npcId;
    private Sprite _icon;
    private bool _canConversationBeHidden;
    private bool _displayRelationshipInfo;
    public string Name => _name;
    public bool CanConversationBeHidden => _canConversationBeHidden;
    public Sprite Icon => _icon;
    public bool DisplayRelationshipInfo => _displayRelationshipInfo;

    public MessageContactInfo(string name, string npcId, Sprite icon, bool canConversationBeHidden, bool displayRelationshipInfo);
    public MessageContactInfo(NPCData npcData);
    public bool IsNull();
    public bool TryGetNPC(out NPC npc);
}