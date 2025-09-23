using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using UnityEngine;

namespace ScheduleOne.Trash;
[Serializable]
public class TrashContent
{
    [Serializable]
    public class Entry
    {
        public string TrashID;
        public int Quantity;
        public int UnitSize { get; private set; }
        public int UnitValue { get; private set; }

        public Entry(string id, int quantity);
    }

    public List<Entry> Entries;
    public void AddTrash(string trashID, int quantity);
    public void RemoveTrash(string trashID, int quantity);
    public int GetTrashQuantity(string trashID);
    public void Clear();
    public int GetTotalSize();
    public TrashContentData GetData();
    public void LoadFromData(TrashContentData data);
}