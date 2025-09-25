using System;

namespace ScheduleOne.Polling;
[Serializable]
public class PollData
{
    public int pollId;
    public string question;
    public string[] answers;
    public int winnerIndex;
    public string confirmationMessage;
}