using System;
using System.Collections.Generic;
using System.IO;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class DeliveriesLoader : Loader
{
    public override void Load(string mainPath);
    public void LoadVehicle(string vehiclePath);
}