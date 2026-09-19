using System.Collections.Generic;
using ScheduleOne.Avatar.Player;
using ScheduleOne.AvatarFramework;
using ScheduleOne.AvatarFramework.Customization;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar.Tools;
public static class BasicAvatarSettingsConverter
{
    private const string MaleUnderwearId;
    private const string FemaleUnderwearId;
    private const string NipplesId;
    private const string EyeShadeId;
    public static NakedAppearance ConvertToNakedAppearance(BasicAvatarSettings legacySettings, bool includeUnderwear, bool includeNipples, bool includeEyeShadow);
    public static PlayerAppearance ConvertToPlayerAppearance(BasicAvatarSettings legacySettings);
}