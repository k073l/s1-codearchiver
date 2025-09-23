using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using UnityEngine;

namespace ScheduleOne.Law;
public static class PenaltyHandler
{
    public const float CONTROLLED_SUBSTANCE_FINE;
    public const float LOW_SEVERITY_DRUG_FINE;
    public const float MED_SEVERITY_DRUG_FINE;
    public const float HIGH_SEVERITY_DRUG_FINE;
    public const float FAILURE_TO_COMPLY_FINE;
    public const float EVADING_ARREST_FINE;
    public const float VIOLATING_CURFEW_TIME;
    public const float ATTEMPT_TO_SELL_FINE;
    public const float ASSAULT_FINE;
    public const float DEADLY_ASSAULT_FINE;
    public const float VANDALISM_FINE;
    public const float THEFT_FINE;
    public const float BRANDISHING_FINE;
    public const float DISCHARGE_FIREARM_FINE;
    public static List<string> ProcessCrimeList(Dictionary<Crime, int> crimes);
}