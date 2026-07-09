using System;
using ScheduleOne.AvatarFramework;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Appearance
{
    public AvatarSettings AvatarSettings;
    public Sprite Mugshot;
    [Header("Seasonal Appearance")]
    public AvatarSettings ChristmasAppearance;
    public Appearance GetCopy();
}