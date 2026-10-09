using System;
using System.Collections.Generic;
using ScheduleOne.Avatar.Player;
using ScheduleOne.Clothing;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.CharacterCreator;
[Serializable]
public class CharacterCreatorState
{
    public PlayerAppearance Appearance;
    public ClothingDefinition TopClothing;
    public EClothingColor TopClothingColor;
    public ClothingDefinition BottomClothing;
    public EClothingColor BottomClothingColor;
    public ClothingDefinition Shoes;
    public EClothingColor ShoesColor;
    public void ReserializeNakedAvatarObjects(List<SerializedAvatarObject> additionalObjects = null);
    public List<SerializedAvatarObject> GetSerializedClothing();
    public List<ClothingInstance> GetClothingInstances();
}