using System;
using ScheduleOne.Messaging;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Messaging
{
    public bool IsKnownByDefault;
    public bool ConversationCanBeHidden;
    public EConversationCategory[] ConversationCategories;
    public Messaging GetCopy();
}