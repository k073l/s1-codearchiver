using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class PropertyLoader : Loader
{
    public override void Load(string mainPath);
    public virtual void Load(PropertyData propertyData, string dataString);
}