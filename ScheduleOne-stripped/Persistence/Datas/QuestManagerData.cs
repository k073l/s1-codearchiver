namespace ScheduleOne.Persistence.Datas;
public class QuestManagerData : SaveData
{
    public QuestData[] Quests;
    public ContractData[] Contracts;
    public DeaddropQuestData[] DeaddropQuests;
    public QuestManagerData(QuestData[] quests, ContractData[] contracts, DeaddropQuestData[] deaddropQuests);
}