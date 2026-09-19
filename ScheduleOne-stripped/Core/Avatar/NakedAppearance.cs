using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[Serializable]
public class NakedAppearance
{
    public float Height;
    public float Gender;
    public float Weight;
    public Color SkinColor;
    public EyebrowSettings LeftEyebrowSettings;
    public EyebrowSettings RightEyebrowSettings;
    public EyeSettings LeftEyeSettings;
    public EyeSettings RightEyeSettings;
    public EyelidSettings LeftEyelidSettings;
    public EyelidSettings RightEyelidSettings;
    public Color HairColor;
    public SerializedAvatarObject[] AvatarObjects;
    public NakedAppearance Clone();
    public NakedAppearance();
    public string ToJson();
    public bool IsValid();
    public bool HasAvatarObject(string id);
    public void AddAvatarObject(SerializedAvatarObject obj);
    public void RemoveAvatarObject(string id);
    public void SetHairAndEyebrowColor(Color color);
}