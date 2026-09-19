using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.Core.Avatar.Properties;
[Serializable]
public class AvatarPropertyCollection
{
    [SerializeField]
    private ColorProperty[] _colors;
    private List<AvatarPropertyBase> _allProperties;
    public List<AvatarPropertyBase> Properties { get; }

    public AvatarPropertyCollection();
    public void Serialize(out SerializedColorProperty[] serializedColors);
    public void Deserialize(SerializedAvatarObject serializedData);
    public void Validate();
    public AvatarPropertyBase GetProperty(string name);
    public T GetProperty<T>(string name)
        where T : AvatarPropertyBase;
    public ColorProperty GetFirstColorProperty();
    private List<AvatarPropertyBase> GetAllProperties();
}