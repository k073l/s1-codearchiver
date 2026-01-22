using System;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.ObjectScripts;
[Serializable]
public class DryingOperation
{
    public string ItemID;
    public int Quantity;
    public EQuality StartQuality;
    public float Time;
    public DryingOperation(string itemID, int quantity, EQuality startQuality, float time);
    public DryingOperation();
    public void IncreaseQuality();
    public QualityItemInstance GetQualityItemInstance();
    public EQuality GetQuality();
}