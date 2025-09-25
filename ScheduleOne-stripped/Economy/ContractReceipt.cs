using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;

namespace ScheduleOne.Economy;
[Serializable]
public class ContractReceipt
{
    public int ReceiptId;
    public EContractParty CompletedBy;
    public string CustomerId;
    public GameDateTime CompletionTime;
    public StringIntPair[] Items;
    public float AmountPaid;
    public ContractReceipt(int receiptId, EContractParty completedBy, string customerID, GameDateTime completionTime, StringIntPair[] items, float amountPaid);
    public ContractReceipt();
}