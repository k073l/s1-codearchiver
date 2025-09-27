using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.Management;
public class ManagementUtilities : Singleton<ManagementUtilities>
{
    public List<string> weedSeedAssetPaths;
    public List<string> additiveAssetPaths;
    public List<AdditiveDefinition> AdditiveDefinitions;
    public static List<string> WeedSeedAssetPaths => Singleton<ManagementUtilities>.Instance.weedSeedAssetPaths;
    public static List<string> AdditiveAssetPaths => Singleton<ManagementUtilities>.Instance.additiveAssetPaths;
}