using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Dialogue;
[Serializable]
public class VocalReactionDatabase
{
    [Serializable]
    public class Entry
    {
        public string Key;
        public string[] Reactions;
        public string name => Key;

        public string GetRandomReaction();
    }

    public List<Entry> Entries;
    public Entry GetEntry(string key);
}