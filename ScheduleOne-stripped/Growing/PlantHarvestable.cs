using FluffyUnderware.DevTools.Extensions;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.Growing;
public class PlantHarvestable : MonoBehaviour
{
    public StorableItemDefinition Product;
    public int ProductQuantity;
    private void Awake();
    public virtual void Harvest(bool giveProduct = true);
}