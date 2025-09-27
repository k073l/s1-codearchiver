using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;
using ScheduleOne.Properties;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
[Serializable]
public class MixOperation
{
    public string ProductID;
    public EQuality ProductQuality;
    public string IngredientID;
    public int Quantity;
    public MixOperation(string productID, EQuality productQuality, string ingredientID, int quantity);
    public MixOperation();
    public EDrugType GetOutput(out List<ScheduleOne.Properties.Property> properties);
    public bool IsOutputKnown(out ProductDefinition knownProduct);
}