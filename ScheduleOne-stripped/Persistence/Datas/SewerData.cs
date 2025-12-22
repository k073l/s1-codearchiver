using System.Collections.Generic;

namespace ScheduleOne.Persistence.Datas;
public class SewerData : SaveData
{
    public bool IsSewerUnlocked;
    public bool IsRandomWorldKeyCollected;
    public int RandomSewerKeyLocationIndex;
    public bool HasSewerKingBeenDefeated;
    public int HoursSinceLastSewerGoblinAppearance;
    public int RandomKeyPossessorIndex;
    public bool RandomKeyPossessorSet;
    public List<int> ActiveMushroomLocationIndices;
    public SewerData(bool isSewerUnlocked, bool isRandomWorldKeyCollected, int randomSewerKeyLocationIndex, bool hasSewerKingBeenDefeated, int hoursSinceLastSewerGoblinAppearance, int randomKeyPossessorIndex, List<int> activeMushroomLocationIndices);
}