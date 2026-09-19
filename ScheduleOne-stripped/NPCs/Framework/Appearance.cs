using System;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Appearance
{
    public Sprite Mugshot;
    public NakedAppearanceObject DefaultAppearance;
    public Outfit DefaultOutfit;
    public Texture2D Impostor;
    public Appearance GetCopy();
}