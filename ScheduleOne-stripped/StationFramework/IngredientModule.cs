using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.StationFramework;
public class IngredientModule : ItemModule
{
    public IngredientPiece[] Pieces;
    public override void ActivateModule(StationItem item);
}