using UnityEngine;

namespace ScheduleOne.Avatar.Player;
[CreateAssetMenu(fileName = "Player Appearance", menuName = "ScheduleOne/Avatar/Player Appearance", order = 1)]
public class PlayerAppearanceObject : ScriptableObject
{
    public PlayerAppearance Appearance;
}