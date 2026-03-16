using System;
using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
public class ProductList
{
    [Serializable]
    public class Entry
    {
        public string ProductID;
        public EQuality Quality;
        public int Quantity;
        public Entry(string productID, EQuality quality, int quantity);
        public Entry();
    }

    public List<Entry> entries;
    public string GetCommaSeperatedString();
    public string GetLineSeperatedString();
    public string GetQualityString();
    public int GetTotalQuantity();
}