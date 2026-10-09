using System;
using ScheduleOne.Avatar.Player;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.PlayerScripts;
[Serializable]
public class FullPlayerData
{
    public PlayerData BasicData;
    public string InventoryString;
    public PlayerAppearance Appearance;
    public string ClothingString;
    public VariableData[] Variables;
    public FullPlayerData(PlayerData basicData, string inventoryString, PlayerAppearance appearance, string clothingString, VariableData[] variables);
    public FullPlayerData();
}