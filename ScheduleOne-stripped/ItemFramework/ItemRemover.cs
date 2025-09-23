using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
public class ItemRemover : MonoBehaviour
{
    public ItemDefinition Item;
    public int Quantity;
    public void Remove();
}