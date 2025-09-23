using System;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Messaging;
[Serializable]
public class Message
{
    public enum ESenderType
    {
        Player,
        Other
    }

    public int messageId;
    public string text;
    public ESenderType sender;
    public bool endOfGroup;
    public Message();
    public Message(string _text, ESenderType _type, bool _endOfGroup = false, int _messageId = -1);
    public Message(TextMessageData data);
    public TextMessageData GetSaveData();
}