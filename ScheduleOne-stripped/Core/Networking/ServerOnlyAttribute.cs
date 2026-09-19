using System;

namespace ScheduleOne.Core.Networking;
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ServerOnlyAttribute : Attribute
{
}