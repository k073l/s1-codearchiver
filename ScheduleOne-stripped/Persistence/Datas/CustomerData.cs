using ScheduleOne.GameTime;
using ScheduleOne.Quests;

namespace ScheduleOne.Persistence.Datas;
public class CustomerData : SaveData
{
    public float Dependence;
    public float[] ProductAffinities;
    public int TimeSinceLastDealCompleted;
    public int TimeSinceLastDealOffered;
    public int OfferedDeals;
    public int CompletedDeals;
    public bool IsContractOffered;
    public ContractInfo OfferedContract;
    public GameDateTime OfferedContractTime;
    public int TimeSincePlayerApproached;
    public int TimeSinceInstantDealOffered;
    public bool HasBeenRecommended;
    public CustomerData(float dependence, float[] productAffinities, int timeSinceLastDealCompleted, int timeSinceLastDealOffered, int offeredDeals, int completedDeals, bool isContractOffered, ContractInfo offeredContract, GameDateTime offeredTime, int timeSincePlayerApproached, int timeSinceInstantDealOffered, bool hasBeenRecommended);
    public CustomerData();
}